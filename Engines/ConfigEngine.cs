using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EnvDTE;
using Zippy.Chirp.Xml;

namespace Zippy.Chirp.Engines {
    public class ConfigEngine : ActionEngine {
        private const string RegularCssFile = ".css";
        private const string RegularJsFile = ".js";
        private const string RegularCoffeeScriptFile = ".coffee";
        private const string RegularLessFile = ".less";
        private const string RegularSassFile = ".sass";
        private const string RegularScssFile = ".scss";
        private Dictionary<string, List<string>> dependentFiles =
       new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);

        public void RefreshAll() {
            var configs = this.dependentFiles.SelectMany(x => x.Value).Distinct(StringComparer.InvariantCultureIgnoreCase);
            foreach (var configFile in configs) {
                this.Refresh(configFile);
            }
        }

        public void Refresh(string configFile) {
            ProjectItem configItem = this.Chirp.App.Solution.FindProjectItem(configFile);

            if (configItem != null) {
                this.Chirp.EngineManager.Enqueue(configItem);
            }
        }

        public void CheckForConfigRefresh(ProjectItem projectItem) {
            string fullFileName = projectItem.FileName();

            if (this.dependentFiles.ContainsKey(fullFileName)) {
                foreach (string configFile in this.dependentFiles[fullFileName]
                    .Distinct(StringComparer.InvariantCultureIgnoreCase) // prevent the same config file from being fired multiple times
                    .ToArray()) {
                    // ToArray to prevent "Collection Modified" exceptions 
                    this.Refresh(configFile);
                }
            }

            if (projectItem.ProjectItems != null) {
                foreach (ProjectItem projectItemInner in projectItem.ProjectItems.Cast<ProjectItem>().ToArray()) {
                    // ToArray to prevent "Collection Modified" exceptions 
                    this.CheckForConfigRefresh(projectItemInner);
                }
            }
        }

        public override int Handles(string fullFileName) {
            this.Settings = Settings.Instance(fullFileName);
            return fullFileName.EndsWith(this.Settings.ChirpConfigFile, StringComparison.InvariantCultureIgnoreCase) ? 1 : 0;
        }

        public override void Run(string fullFileName, ProjectItem projectItem)
        {

            var fileGroups = this.LoadConfigFileGroups(fullFileName);
            string directory = Path.GetDirectoryName(fullFileName);
            var productionFileText = new StringBuilder();

            using (var manager = new Manager.VSProjectItemManager(this.Chirp != null ? this.Chirp.App : null, projectItem))
            {
                foreach (var fileGroup in fileGroups)
                {
                    productionFileText.Clear();

                    bool isJS = this.IsJsFile(fileGroup.GetName);
                    bool isCSS = this.IsCssFile(fileGroup.GetName);

                    string fullPath = directory + @"\" + fileGroup.Name;
                    if (!string.IsNullOrEmpty(fileGroup.Path))
                    {
                        fullPath = fileGroup.Path;
                    }
                    string fullPathMin = Utilities.GetBaseFileName(fullPath) + (isJS ? this.Settings.OutputExtensionJS : this.Settings.OutputExtensionCSS);
                    if (TaskList.Instance != null)
                    {
                        TaskList.Instance.Remove(fullPath);
                        TaskList.Instance.Remove(fullPathMin);
                    }

                    if (ImageSprite.IsImage(fileGroup.GetName))
                    {
                        var img = ImageSprite.Build(fileGroup, fullPath);
                        manager.AddFileByFileName(fullPath, img);
                        continue;
                    }

                    foreach (var file in fileGroup.Files)
                    {
                        var path = file.Path;
                        string code = file.GetCode();
                        string customArg = file.CustomArgument;

                        if ((this.IsLessFile(path) || this.IsSassFile(path) || this.IsCoffeeScriptFile(path) || file.Minify == true) && TaskList.Instance != null)
                        {
                            TaskList.Instance.Remove(path);
                        }

                        if (fileGroup.Debug)
                        {
                            var debugCode = "\r\n/* Chirpy Minify: {Minify}, MinifyWith: {MinifyWith}, File: {FilePath} */\r\n{Code}"
                                .F(new
                                {
                                    Minify = file.Minify.GetValueOrDefault(),
                                    FilePath = path,
                                    Code = isJS ? UglifyEngine.Beautify(code) : code,
                                    MinifyWith = file.MinifyWith.ToString()
                                });
                            productionFileText.AppendLine(debugCode);
                        }

                        if (this.IsLessFile(path))
                        {
                            code = LessEngine.TransformToCss(path, code, projectItem);
                        }
                        else if (this.IsCoffeeScriptFile(path))
                        {
                            code = CoffeeScriptEngine.TransformToJs(path, code, projectItem);
                        }
                        else if (this.IsSassFile(path))
                        {
                            code = SassEngine.TransformToCss(path, code, projectItem);
                        }

                        if (file.Minify == true)
                        {
                            if (this.IsCssFile(path))
                            {
                                code = CssEngine.Minify(path, code, projectItem, file.MinifyWith);
                            }
                            else if (this.IsJsFile(path))
                            {
                                code = JsEngine.Minify(path, code, projectItem, file.MinifyWith, customArg);
                            }
                        }
                        productionFileText.AppendLine(code);
                    }

                    string output = productionFileText.ToString();
                    output = Utilities.ProcessText(output, fileGroup.Find, fileGroup.Replace);

                    if (fileGroup.Minify == FileGroupXml.MinifyActions.True)
                    {
                        output = isJS ? JsEngine.Minify(fullPath, output, projectItem, fileGroup.MinifyWith)
                            : CssEngine.Minify(fullPath, output, projectItem, fileGroup.MinifyWith);
                    }

                    //manager.AddFileByFileName(Utilities.GetBaseFileName(fullPath) + (isJS ? ".js" : isCSS ? ".css" : System.IO.Path.GetExtension(fullPath)), output);
                    manager.AddFileByFileName(fullPath, output);

                    if (fileGroup.Minify == FileGroupXml.MinifyActions.Both)
                    {
                        if (TaskList.Instance != null)
                        {
                            TaskList.Instance.Remove(fullPathMin);
                        }

                        output = isJS ? JsEngine.Minify(fullPath, output, projectItem, fileGroup.MinifyWith)
                            : CssEngine.Minify(fullPath, output, projectItem, fileGroup.MinifyWith);
                        manager.AddFileByFileName(fullPathMin, output);
                    }

                }

                if (projectItem != null)
                {
                    this.ReloadFileDependencies(projectItem);
                }
            }

        }

        /// <summary>
        /// build a dictionary that has the files that could change as the key.
        /// for the value it is a LIST of config files that need updated if it does change.
        /// so, when a .less.css file changes, we look in the list and rebuild any of the configs associated with it.
        /// if a config file changes...this rebuild all of this....
        /// </summary>
        /// <param name="projectItem">project Item</param>
        internal void ReloadFileDependencies(ProjectItem projectItem) {
            string configFileName = projectItem.FileName();

            // remove all current dependencies for this config file...
            foreach (string key in this.dependentFiles.Keys.ToArray()) {
                List<string> files = this.dependentFiles[key];
                if (files.Remove(configFileName) && files.Count == 0) {
                    this.dependentFiles.Remove(key);
                }
            }

            IEnumerable<string> dependents;
            if (IsLessFile(configFileName))
            {
                var root = System.IO.Path.GetDirectoryName(projectItem.ContainingProject.FullName);
                var text = System.IO.File.ReadAllText(configFileName);
                var imports = LessEngine.FindDependencies(configFileName, text, root);
                dependents = imports.Where(x => x.IsFile).Select(x => x.LocalPath);

            } else {
                var fileGroups = this.LoadConfigFileGroups(configFileName);
                dependents = fileGroups.SelectMany(x => x.Files).Select(x => x.Path);

            }

            foreach (var file in dependents) {
                if (!this.dependentFiles.ContainsKey(file)) {
                    this.dependentFiles.Add(file, new List<string> { configFileName });
                } else {
                    this.dependentFiles[file].Add(configFileName);
                }
            }
        }

        private bool IsLessFile(string fileName) {
            return (fileName.EndsWith(RegularLessFile, StringComparison.OrdinalIgnoreCase)|| Settings.AllLessExtensions.Any(x=>fileName.EndsWith(x,StringComparison.OrdinalIgnoreCase)));
        }

        private bool IsCoffeeScriptFile(string fileName) {
            return fileName.EndsWith(RegularCoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsCssFile(string fileName) {
            return fileName.EndsWith(RegularCssFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsJsFile(string fileName) {
            return fileName.EndsWith(RegularJsFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsSassFile(string fileName) {
            return fileName.EndsWith(RegularSassFile, StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(RegularScssFile, StringComparison.OrdinalIgnoreCase);
        }

        private IList<FileGroupXml> LoadConfigFileGroups(string configFileName) {
            try {
                 XDocument doc = XDocument.Load(configFileName);

                string appRoot = string.Format("{0}\\", Path.GetDirectoryName(configFileName));

                IList<FileGroupXml> returnList = doc.Descendants("FileGroup")
                        .Concat(doc.Descendants(XName.Get("FileGroup", "urn:ChirpyConfig")))
                    .Select(n => new FileGroupXml(n, appRoot))
                    .ToList();

                return returnList;
            } catch (System.Xml.XmlException eError) {
                if (!eError.Message.Contains("Root element not found") && !eError.Message.Contains("Root element is missing")) {
                    throw eError;
                }

                return new List<FileGroupXml>(); //return empty list
            }
        }
    }
}
