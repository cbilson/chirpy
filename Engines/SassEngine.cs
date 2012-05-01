using System;
using System.Linq;
using SassAndCoffee.Core.Sass;
using Zippy.Chirp.Xml;

namespace Zippy.Chirp.Engines
{
    /// <summary>
    /// Engine for Sass and scss
    /// </summary>
    public class SassEngine : TransformEngine
    {
        public SassEngine()
        {
            Extensions = new[] { this.Settings.ChirpSassFile, this.Settings.ChirpScssFile };
            OutputExtension = this.Settings.OutputExtensionCSS;
        }

        public static string TransformToCss(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            string output = string.Empty;
            using (var fixture = new SassCompiler())
            {
                output = fixture.Compile(fullFileName);
            }

            return output;
        }

        public override string Transform(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            string result = TransformToCss(fullFileName, text, projectItem);

            return result;
        }

        public override int Handles(string fullFileName)
        {
            this.Settings = Settings.Instance(fullFileName);
            var match = Extensions.Where(x => fullFileName.EndsWith(x, StringComparison.InvariantCultureIgnoreCase))
                          .FirstOrDefault() ?? string.Empty;
            return match.Length;
        }

        public override void Process(Manager.VSProjectItemManager manager, string fullFileName, EnvDTE.ProjectItem projectItem, string baseFileName, string outputText)
        {
            base.Process(manager, fullFileName, projectItem, baseFileName, outputText);

            var mode = this.GetMinifyType(fullFileName);
            string mini = CssEngine.Minify(fullFileName, outputText, projectItem, mode);
            manager.AddFileByFileName(baseFileName + this.Settings.OutputExtensionCSS, mini);
        }

        public MinifyType GetMinifyType(string fullFileName)
        {
            this.Settings = Settings.Instance(fullFileName);
            MinifyType mode = MinifyType.yui;
            if (this.IsChirpMichaelAshFile(fullFileName) || this.IsChirpHybridFile(fullFileName) || this.IsChirpFile(fullFileName))
            {
                mode = this.IsChirpMichaelAshFile(fullFileName) ? MinifyType.yuiMARE
               : this.IsChirpHybridFile(fullFileName) ? MinifyType.yuiHybrid
               : MinifyType.yui;
            }

            if (this.IsChirpMSAjaxFile(fullFileName))
            {
                mode = MinifyType.msAjax;
            }

            return mode;
        }

        private bool IsChirpFile(string fileName)
        {
            return (fileName.EndsWith(this.Settings.ChirpSassFile, StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(this.Settings.ChirpScssFile, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsChirpHybridFile(string fileName)
        {
            return (fileName.EndsWith(this.Settings.ChirpHybridSassFile, StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(this.Settings.ChirpHybridScssFile, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsChirpMichaelAshFile(string fileName)
        {
            return (fileName.EndsWith(this.Settings.ChirpMichaelAshSassFile, StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(this.Settings.ChirpMichaelAshScssFile, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsChirpMSAjaxFile(string fileName)
        {
            return (fileName.EndsWith(this.Settings.ChirpMSAjaxSassFile, StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(this.Settings.ChirpMSAjaxScssFile, StringComparison.OrdinalIgnoreCase));
        }
    }
}
