using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Zippy.Chirp.JavaScript {
    public class JSHint : JavaScript {
        public JSHint(string code, object data)
            : base(code, data, new Requirement {
                Path = "https://raw.github.com/jshint/jshint/master/jshint.js",
                PostSource = "exports.JSHINT = window.JSHINT = JSHINT;"
            }) { }

        [ComVisible(true)]
        public class options {
            [Description("Prohibit the use of bitwise operators"), Category("Options")]
            public bool bitwise { get; set; }

            [Description("Allow assignments inside if/for/while/do"), Category("Options")]
            public bool boss { get; set; }

            [Description("Require curly braces around all blocks"), Category("Options")]
            public bool curly { get; set; }

            [Description("Allow debugger statements"), Category("Options")]
            public bool debug { get; set; }

            [BrowsableAttribute(false)]
            public bool devel { get; set; }

            [Description("Require that you use === and !== for all comparisons"), Category("Options")]
            public bool eqeqeq { get; set; }

            [Description("Allow the use of eval"), Category("Options")]
            public bool evil { get; set; }

            [Description("Disallow the use of for in without hasOwnProperty"), Category("Options")]
            public bool forin { get; set; }

            [Description("Require immediate invocations to be wrapped in parens"), Category("Options")]
            public bool immed { get; set; }

            [Description("Not check line breaks"), Category("Options")]
            public bool laxbreak { get; set; }

            [Description("Maximum number of errors before stops processing your source"), Category("Options")]
            public int? maxerr { get; set; }

            [Description("Require that you capitalize all constructor functions"), Category("Options")]
            public bool newcapp { get; set; }

            [Description("Prohibit the use of arguments.caller and arguments.callee"), Category("Options")]
            public bool noarg { get; set; }

            [Description("Prohibit the use of empty blocks"), Category("Options")]
            public bool noempty { get; set; }

            [Description("Prohibit the use of constructors for side-effects"), Category("Options")]
            public bool nonew { get; set; }

            [Description("Disallow the use of initial or trailing underbars in names"), Category("Options")]
            public bool nomen { get; set; }

            [Description("Allow only one var statement per function"), Category("Options")]
            public bool novar { get; set; }

            [Description("Stop on the first error it encounter"), Category("Options")]
            public bool passfail { get; set; }

            [Description("Prohibit the use of increment and decrement operators"), Category("Options")]
            public bool plusplus { get; set; }

            [Description("Disallow . and [^...] in regular expressions"), Category("Options")]
            public bool regex { get; set; }

            [Description("Require all non-global variables be declared before they are used"), Category("Options")]
            public bool undef { get; set; }

            [Description("Tolerate all forms of subscript notation"), Category("Options")]
            public bool sub { get; set; }

            [Description("Require you to use \"use strict\"; pragma"), Category("Options")]
            public bool strict { get; set; }

            [Description("Check your code against strict whitespace rules"), Category("Options")]
            public bool white { get; set; }
        }

        public class result {
            public int line { get; set; }
            public int character { get; set; }
            public string reason { get; set; }
            public string evidence { get; set; }
            public string raw { get; set; }
        }

        //private static object get(Dictionary<string, object> dic, string name) {
        //    object value;
        //    if (dic == null) return null;
        //    else if (dic.TryGetValue(name, out value)) return value;
        //    else return null;
        //}

        private List<result> _Results = new List<result>();
        public void AddResult(int line, int character, string reason, string evidence, string raw) {
            _Results.Add(new result { line = line, character = character, reason = reason, evidence = evidence, raw = raw });
        }

        public static result[] JSHINT(string source, options options = null) {
            var data = new Dictionary<string, object> {
                {"source", source},
                {"options", options},
            };
            var optionCode = "";
            if (options != null) {
                foreach (var prop in typeof(options).GetProperties()) {
                    optionCode += "\r\n\t'" + prop.Name + "': options0['" + prop.Name + "'],";
                }
            }
            var ie = new JSHint(@"
                    var options0 = external.Get('options'), options1 = {
                        " + optionCode.TrimEnd(',') + @"
                    }, result = JSHINT(external.Get('source'), options1), 
                       errors = JSHINT.errors;
                    external.Set('result', result);
                    external.Set('errors', errors.length);
                    if (!result) {
                        for (var i = 0; i < errors.length; i++) {
                            external.AddResult(errors[i].line || 0, errors[i].character || 0, errors[i].reason || '', errors[i].evidence || '', errors[i].raw || '');
                        }
                    }
                ", data);
            ie.Execute();
            var result = ie.Get("result") as bool?;

            if (result ?? ie._Results.Count == 0) return null;
            return ie._Results.ToArray();
        }
    }
}
