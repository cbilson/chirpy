using System;
using Microsoft.Ajax.Utilities;

namespace Zippy.Chirp.Engines
{
    public class MsCssEngine : CssEngine
    {
        public MsCssEngine()
        {
            Extensions = new[] { this.Settings.ChirpMSAjaxCssFile };
            OutputExtension = this.Settings.OutputExtensionCSS;
        }

        public static string Minify(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            Settings settings = Settings.Instance(fullFileName);
            return Minify(fullFileName, text, projectItem, settings.MsCssSettings);
        }

        public static string Minify(string fullFileName, string text, EnvDTE.ProjectItem projectItem,CssSettings cssSettings)
        {
            Minifier minifier = new Minifier();
            string miniCss = minifier.MinifyStyleSheet(text, cssSettings);

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

            return miniCss;
        }

        public override string Transform(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            return Minify(fullFileName, text, projectItem,this.Settings.MsCssSettings);
        }
    }
}
