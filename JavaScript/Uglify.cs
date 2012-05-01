using System;
using System.Collections.Generic;

namespace Zippy.Chirp.JavaScript {

    public static class Uglify {

        public static string squeeze_it(string source, Action<int, int, string> onerror = null) {
            var obj = JavaScript.Execute(@"external.Set('source', module.exports(external.Get('source')));",
               new Dictionary<string, object> { { "source", source } },
               "https://raw.github.com/mishoo/UglifyJS/master/uglify-js.js");

            if (onerror != null) {
                foreach (var msg in obj.Messages) {
                    onerror(msg.Line + 1, msg.Column, msg.Content);
                }
            }

            return obj.Get("source") as string;
        }

    }

}
