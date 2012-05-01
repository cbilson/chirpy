using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EnvDTE;
using EnvDTE80;
using System.IO;

namespace Zippy.Chirp {
    public static class Utilities {
        private const char ENUM_SEPERATOR_CHARACTER = ',';
        private static Dictionary<Enum, string> descriptions = new Dictionary<Enum, string>();
        private static Regex rxIsRegex = new Regex("^/(.*?)/([a-z]*)$", RegexOptions.Compiled);

        public static void Dispose<T>(ref T obj) where T : class, IDisposable {
            try {
                if (obj != null) {
                    obj.Dispose();
                }
            } catch {
            }

            obj = null;
        }

        public static void MakeWritable(string filename) {
            var attrs = File.GetAttributes(filename);
            if ((attrs & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) {
                File.SetAttributes(filename, attrs & ~FileAttributes.ReadOnly);
            }
        }

        private static Regex rxNormalizeLineEndings = new Regex(@"\r\n|\n\r|\n|\r", RegexOptions.Compiled);
        public static string ProcessText(string input, string find, string replace) {
            input = rxNormalizeLineEndings.Replace(input, "\r\n");
            if (find.IsNullOrEmpty()) return input;

            var match = rxIsRegex.Match(find);
            if (match.Success) {
                var options = RegexOptions.Compiled | RegexOptions.Singleline;
                if (match.Groups[2].Value.Contains("i"))
                    options |= RegexOptions.IgnoreCase;
                return Regex.Replace(input, match.Groups[1].Value, replace ?? string.Empty, options);
            }

            return input.Replace(find, replace ?? string.Empty);
        }

        public static void Clear(this System.Text.StringBuilder str) {
            if (str.Length == 0) return;
            str.Remove(0, str.Length);
        }

        /// <summary>
        /// Looks for the <see cref="System.ComponentModel.DescriptionAttribute">DescriptionAttribute</see> on an
        /// enum, and returns the value.
        /// </summary>
        /// <param name="e">enum type</param>
        /// <returns>Description attribute</returns>    
        public static string Description(this Enum e) {
            lock (Utilities.descriptions) {
                if (!Utilities.descriptions.ContainsKey(e)) {
                    var entries = e.ToString().Split(ENUM_SEPERATOR_CHARACTER);
                    string[] desc = new string[entries.Length];
                    Type type = e.GetType();
                    for (int i = 0; i <= entries.Length - 1; i++) {
                        var fieldinfo = type.GetField(entries[i].Trim());
                        if (fieldinfo != null) {
                            var attr = fieldinfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false)
                                .FirstOrDefault() as System.ComponentModel.DescriptionAttribute;
                            desc[i] = attr != null ? attr.Description : entries[i].Trim().Replace("_", " ");
                        } else {
                            desc[i] = entries[i].Trim().Replace("_", " ");
                        }
                    }

                    Utilities.descriptions.Add(e, string.Join(ENUM_SEPERATOR_CHARACTER.ToString(), desc));
                }

                return Utilities.descriptions[e];
            }
        }

        public static ProjectItem LocateProjectItemForFileName(this DTE2 app, string fileName) {
            foreach (Project project in app.Solution.Projects) {
                foreach (ProjectItem projectItem in project.ProjectItems.ProcessFolderProjectItemsRecursively()) {
                    if (projectItem.FileName() == fileName) {
                        return projectItem;
                    }
                }
            }

            return null;
        }

        public static bool IsFolder(this ProjectItem item) {
            return item.Kind == Constants.vsProjectItemKindPhysicalFolder;
        }

        public static string FileName(this ProjectItem item)
        {
            try
             {
                //regular project
                return item.get_FileNames(1);
            }
            catch (Exception)
            {
                //VS.Php
                return item.get_FileNames(0);
            }
        }

        public static bool IsSolutionFolder(this ProjectItem item) {
            return item.SubProject != null;
        }

        public static IEnumerable<ProjectItem> ProcessFolderProjectItemsRecursively(this ProjectItems projectItems) {
            if (projectItems != null) {
                foreach (ProjectItem projectItem in projectItems) {
                    if (projectItem.IsFolder() && projectItem.ProjectItems != null) {
                        foreach (ProjectItem folderProjectItem in ProcessFolderProjectItemsRecursively(projectItem.ProjectItems)) {
                            yield return folderProjectItem;
                        }
                    } else if (projectItem.IsSolutionFolder()) {
                        foreach (ProjectItem solutionProjectItem in ProcessFolderProjectItemsRecursively(projectItem.SubProject.ProjectItems)) {
                            yield return solutionProjectItem;
                        }
                    } else {
                        yield return projectItem;
                    }
                }
            }
        }

        public static IEnumerable<ProjectItem> GetAll(this ProjectItems projectItems) {
            foreach (ProjectItem projectItem in projectItems) {
                foreach (ProjectItem subItem in GetAll(projectItem.ProjectItems)) {
                    yield return subItem;
                }

                yield return projectItem;
            }
        }

        public static ProjectItem GetParent(this ProjectItem projectItem) {
            if (projectItem.Collection == null) {
                return null;
            } else {
                return projectItem.Collection.Parent as ProjectItem;
            }
        }

        /// <summary>
        /// Returns "C:\fakepath\test" when given "C:\fakepath\test.js"
        /// </summary>
        /// <param name="fullFileName">full file name</param>
        /// <param name="extensions">file extension</param>
        /// <returns>Base filename "C:\fakepath\test"</returns>
        public static string GetBaseFileName(string fullFileName, params string[] extensions) {
            var settings = Settings.Instance(fullFileName);
            extensions = extensions == null ? settings.AllExtensions : extensions.Union(settings.AllExtensions).ToArray();

            var fileExt = extensions.Where(x => fullFileName.EndsWith(x, StringComparison.InvariantCultureIgnoreCase)).OrderByDescending(x => x.Length).FirstOrDefault()
                ?? System.IO.Path.GetExtension(fullFileName);

            if (!string.IsNullOrEmpty(fileExt)) {
                fullFileName = fullFileName.Substring(0, fullFileName.Length - fileExt.Length);
            }

            return fullFileName;
        }
    }
}
