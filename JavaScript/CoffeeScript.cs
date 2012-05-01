
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
namespace Zippy.Chirp.JavaScript {
    public static class CoffeeScript {
        public class options {
            [Description("Compile the JavaScript without the top-level function safety wrapper"), Category("Options")]
            public bool bare { get; set; }
        }

        private static Regex rxDetectOptions = new Regex(@"/\*\s*CoffeeScript\:\s*(.*?)\*/", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        public static string compile(string source, options options = null) {
            var script = "external.Set('result', CoffeeScript.compile(external.Get('source'), options));";
            var moptions = rxDetectOptions.Match(source);
            if (moptions.Success) {
                script = "var options = { " + moptions.Groups[1].Value + "}; " + script;
                source = source.Remove(moptions.Index, moptions.Length);
            } else if (options != null) {
                script = string.Format("var options = {{ 'bare': {0} }}; ", options.bare.ToString().ToLower()) + script;
            } else {
                script = "var options = undefined; " + script;
            }

            var js = JavaScript.Execute(script,
                 new Dictionary<string, object> { { "source", source } },
                 new JavaScript.Requirement { Path = "http://jashkenas.github.com/coffee-script/extras/coffee-script.js" });

            return js.Get("result") as string;
        }
    }
}
