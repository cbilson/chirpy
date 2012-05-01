using System;
using Microsoft.Ajax.Utilities;

namespace Zippy.Chirp.Engines
{
    public class MsJsEngine : JsEngine
    {
        public MsJsEngine()
        {
            Extensions = new[] { this.Settings.ChirpMSAjaxJsFile };
            OutputExtension = this.Settings.OutputExtensionJS;
        }

        public static string Minify(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            Settings settings = Settings.Instance(fullFileName);
            return Minify(fullFileName, text, projectItem, settings.MsJsSettings);
        }

        public static string Minify(string fullFileName, string text, EnvDTE.ProjectItem projectItem,CodeSettings codeSettings)
        {
            Minifier minifier = new Minifier();
            
             string mini = minifier.MinifyJavaScript(text,codeSettings);

            foreach (var err in minifier.ErrorList)
            {
               if (TaskList.Instance == null)
                {
                    Console.WriteLine(string.Format("{0}({1},{2}){3}", fullFileName, 1, 1, err));
                }
                else
                {
                    TaskList.Instance.Add(projectItem.ContainingProject, Microsoft.VisualStudio.Shell.TaskErrorCategory.Error, fullFileName, err.StartLine, err.StartColumn, err.Message);
                }
            }

            return mini;
        }

        public override string Transform(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            return Minify(fullFileName, text, projectItem, this.Settings.MsJsSettings);
        }
    }
}
