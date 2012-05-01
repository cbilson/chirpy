using System;
using System.Xml.Linq;

namespace Zippy.Chirp.Xml {
    public class FileXml {
        #region "constructor"
        public FileXml() { }

        public FileXml(XElement xElement)
            : this(xElement, string.Empty) {
        }

        public FileXml(XElement xElement, string basePath) {
            var path = (string)xElement.Attribute("Path");
            this.Type = ((string)xElement.Attribute("Type")).ToEnum(Types.Unspecified);
            if (this.Type == Types.Unspecified) {
                this.Type = path.EndsWith(".js", StringComparison.OrdinalIgnoreCase)
                    ? Types.JS : Types.CSS;
            }

            if (xElement.Name.LocalName == "Raw" && path.IsNullOrEmpty()) {
                path = "~raw." + this.Type.ToString().ToLower();
            }

            var minify = (string)xElement.Attribute("Minify");

            if (path == null) {
                throw new Exception("Path attribute required on File element");
            }

            Uri uri;
            if (Uri.TryCreate(path, UriKind.Absolute, out uri) && (uri.Scheme == "http" || uri.Scheme == "https")) {
                path = null;
                JavaScript.Extensibility.Instance.Download(uri, ref path);
                this.Path = path;

            } else {
                this.Path = System.IO.Path.GetFullPath(  //to process "..\" references
                       System.IO.Path.Combine(basePath, path)
                   );
            }

            this.Minify = minify.TryToBool();

            this.MinifyWith = ((string)xElement.Attribute("MinifyWith")).ToEnum(MinifyType.Unspecified);

            this.CustomArgument = (string)xElement.Attribute("CustomArgument");

            this.Code = xElement.Value;

            this.Find = (string)xElement.Attribute("Find");

            this.Replace = (string)xElement.Attribute("Replace");
        }
        #endregion

        public string Path { get; set; }

        public bool? Minify { get; set; }

        public MinifyType MinifyWith { get; set; }

        public string CustomArgument { get; set; }

        public string Find { get; set; }

        public string Replace { get; set; }

        public string Code { get; set; }

        public Types Type { get; set; }

        public enum Types {
            Unspecified, CSS, JS
        }

        public string GetCode() {
            var code = !Code.IsNullOrEmpty() ? this.Code : System.IO.File.ReadAllText(Path);
            code = Utilities.ProcessText(code, this.Find, this.Replace);
            return code;
        }
    }
}
