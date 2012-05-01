using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zippy.Chirp.Engines 
{
    public class ViewEngine : TransformEngine 
    {
        private static Regex regexScripts = new Regex(@"\<(style|script)([^>]*)\>(.*?)\</\1\>", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public ViewEngine()
        {
            Extensions = new[] { this.Settings.ChirpViewFile, this.Settings.ChirpPartialViewFile, this.Settings.ChirpRazorCSViewFile, this.Settings.ChirpRazorVBViewFile };
            OutputExtension = this.Settings.ChirpViewFile;
        }

        public override string GetOutputExtension(string fullFileName) 
        {
            return System.IO.Path.GetExtension(fullFileName);
        }

        public override int Handles(string fullFileName) 
        {
            this.Settings = Settings.Instance(fullFileName);
            if (fullFileName.EndsWith(this.Settings.ChirpViewFile, System.StringComparison.InvariantCultureIgnoreCase))
            {
                return 1;
            }
            else if (fullFileName.EndsWith(this.Settings.ChirpPartialViewFile, System.StringComparison.InvariantCultureIgnoreCase))
            {
                return 1;
            }
            else if (fullFileName.EndsWith(this.Settings.ChirpRazorCSViewFile, System.StringComparison.InvariantCultureIgnoreCase))
            { 
                return 1; 
            }
            else if (fullFileName.EndsWith(this.Settings.ChirpRazorVBViewFile, System.StringComparison.InvariantCultureIgnoreCase))
            {
                return 1;
            }
            else 
            {
                return 0; 
            }
        }

        public override string Transform(string fullFileName, string text, EnvDTE.ProjectItem projectItem) 
        {
            var tags = regexScripts.Matches(text).Cast<Match>().Reverse();

            foreach (var match in tags)
            {
                var tagName = match.Groups[1].Value;
                var attrs = match.Groups[2].Value;
                var code = match.Groups[3].Value;

                if (tagName.Is("script")) 
                {
                    code = JsEngine.Minify(fullFileName, code, projectItem, Xml.MinifyType.Unspecified,string.Empty);
                } 
                else if (tagName.Is("style")) 
                {
                    int i = attrs.IndexOf("text/less", StringComparison.InvariantCultureIgnoreCase);
                    if (i > -1)
                    {
                        attrs = attrs.Substring(0, i) + "text/css" + attrs.Substring(i + "text/less".Length);
                        code = code.Replace("@@import", "@import"); // Razor views need the @ symbol to be escaped :/
                        code = LessEngine.TransformToCss(fullFileName, code, projectItem);
                        code = code.Replace("@import", "@@import"); // Now we have to re-escape it
                    }

                    code = CssEngine.Minify(fullFileName, code, projectItem, Xml.MinifyType.Unspecified);
                }

                text = text.Substring(0, match.Index)
                    + '<' + tagName + attrs + '>' + code + "</" + tagName + '>'
                    + text.Substring(match.Index + match.Length);
            }

            return text;
        }
    }
}
