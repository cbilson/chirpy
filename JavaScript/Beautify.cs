using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Zippy.Chirp.JavaScript {
    public static class Beautify {
        public class options {
            public options() {
                indent_size = 4;
                indent_char = " ";
                preserve_newlines = true;
                max_preserve_newlines = 0;
                indent_level = 0;
                space_after_anon_function = false;
                keep_array_indentation = false;
            }

            public int indent_size { get; set; }
            public string indent_char { get; set; }
            public bool preserve_newlines { get; set; }
            public int max_preserve_newlines { get; set; }
            public int indent_level { get; set; }
            public bool space_after_anon_function { get; set; }
            public bool keep_array_indentation { get; set; }
        }

        private static Regex rxDetectOptions = new Regex(@"/\*\s*Beautify\:\s*(.*?)\*/", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        public static string js_beautify(string code, options options = null) {
            var data = new Dictionary<string, object> {
                {"code", code},
                {"options", options},
            };
            var optionCode = "";
            var moptions = rxDetectOptions.Match(code);
            if (moptions.Success) {
                optionCode = moptions.Groups[1].Value;
                code = code.Remove(moptions.Index, moptions.Length);

            } else if (options != null) {
                foreach (var prop in typeof(options).GetProperties()) {
                    optionCode += "\r\n\t'" + prop.Name + "': options0['" + prop.Name + "'],";
                }
            }

            var js = JavaScript.Execute(@"var options0 = external.Get('options'), options1 = {
                        " + optionCode.TrimEnd(',') + @"
                    };
                    external.Set('result', js_beautify(external.Get('code'), options1));",
                new Dictionary<string, object> { { "code", code }, { "options", options } },
                new JavaScript.Requirement { Path = "http://jsbeautifier.org/beautify.js", PostSource = "window.js_beautify = js_beautify;" });

            return js.Get("result") as string;
        }
    }
}
