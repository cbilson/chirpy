using System;
using System.Text.RegularExpressions;
using Zippy.Chirp.Xml;
using Zippy.Chirp.JavaScript;

namespace Zippy.Chirp.Engines
{
    public class CoffeeScriptEngine : TransformEngine
    {
        private static Regex regexError = new Regex(@"Error\:\s*(.*?)\s+on\s+line\s+([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled); // "Error: unclosed { on line 1"

        public CoffeeScriptEngine()
        {
            Extensions = new[] { this.Settings.ChirpCoffeeScriptFile, this.Settings.ChirpGctCoffeeScriptFile, this.Settings.ChirpMSAjaxCoffeeScriptFile, this.Settings.ChirpSimpleCoffeeScriptFile, this.Settings.ChirpWhiteSpaceCoffeeScriptFile, this.Settings.ChirpYUICoffeeScriptFile };
            OutputExtension = ".js";
        }

        public static string TransformToJs(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            string error = null;
            try
            {
               Settings settings = Settings.Instance(fullFileName);
               return CoffeeScript.compile(text, settings.CoffeeScriptOptions);
            }
            catch (Exception e)
            {
                Match match;
                if (TaskList.Instance != null && (match = regexError.Match(e.Message)).Success)
                {
                    TaskList.Instance.Add(
                        projectItem.ContainingProject,
                        Microsoft.VisualStudio.Shell.TaskErrorCategory.Error,
                        fullFileName,
                        match.Groups[2].Value.ToInt(1),
                        0,
                        match.Groups[1].Value);
                }
                else
                {
                    error = e.Message;
                }

                return null;
            }
        }

        public override string Transform(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            return TransformToJs(fullFileName, text, projectItem);
        }

        public override void Process(Manager.VSProjectItemManager manager, string fullFileName, EnvDTE.ProjectItem projectItem, string baseFileName, string outputText)
        {
            base.Process(manager, fullFileName, projectItem, baseFileName, outputText);

            var mode = this.GetMinifyType(fullFileName);
            string mini = JsEngine.Minify(fullFileName, outputText, projectItem, mode,string.Empty);
            manager.AddFileByFileName(baseFileName + this.Settings.OutputExtensionJS, mini);
        }

        public MinifyType GetMinifyType(string fullFileName)
        {
            this.Settings = Settings.Instance(fullFileName);
            MinifyType mode = MinifyType.gctAdvanced;

            if (this.IsChirpGctCoffeeScriptFile(fullFileName))
            {
                mode = MinifyType.gctAdvanced;
            }

            if (this.IsChirpMSAjaxCoffeeScriptFile(fullFileName))
            {
                mode = MinifyType.msAjax;
            }

            if (this.IsChirpSimpleCoffeeScriptFile(fullFileName))
            {
                mode = MinifyType.gctSimple;
            }

            if (this.IsChirpWhiteSpaceCoffeeScriptFile(fullFileName))
            {
                mode = MinifyType.gctWhiteSpaceOnly;
            }

            if (this.IsChirpYUICoffeeScriptFile(fullFileName))
            {
                mode = MinifyType.yui;
            }

            if (this.IsChirpUglifyCoffeeScriptFile(fullFileName))
            {
                mode = MinifyType.uglify;
            }

            return mode;
        }

        private bool IsChirpCoffeeScriptFile(string fileName)
        {
            return fileName.EndsWith(this.Settings.ChirpCoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsChirpGctCoffeeScriptFile(string fileName)
        {
            return fileName.EndsWith(this.Settings.ChirpGctCoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsChirpMSAjaxCoffeeScriptFile(string fileName)
        {
            return fileName.EndsWith(this.Settings.ChirpMSAjaxCoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsChirpSimpleCoffeeScriptFile(string fileName)
        {
            return fileName.EndsWith(this.Settings.ChirpSimpleCoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsChirpWhiteSpaceCoffeeScriptFile(string fileName)
        {
            return fileName.EndsWith(this.Settings.ChirpWhiteSpaceCoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsChirpYUICoffeeScriptFile(string fileName)
        {
            return fileName.EndsWith(this.Settings.ChirpYUICoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsChirpUglifyCoffeeScriptFile(string fileName)
        {
            return fileName.EndsWith(this.Settings.ChirpUglifyCoffeeScriptFile, StringComparison.OrdinalIgnoreCase);
        }
    }
}

