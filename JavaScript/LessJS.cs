using System;
using System.Collections.Generic;

namespace Zippy.Chirp.JavaScript {
    public static class Less {
        public static string render(string code, Action<int, int, string> onerror = null) {

            var js = new JavaScript(@"
                less.Parser().parse(external.Get('code'), function(err, tree){
                    console.log('done');
                    if(err) {
                        external.AddMessage(err.line || 0, err.column || 0, 2, err.message + ': ' err.extract.join(' '));
                    } else {
                        external.Set('result', tree.toCSS());
                    }
                    external.Finished();
                });
                ", new Dictionary<string, object> { { "code", code } },
                  new JavaScript.Requirement { Path = "https://raw.github.com/cloudhead/less.js/master/dist/less-1.1.4.js", PostSource = "window.less = less;" });

            js.AutoFinish = false;
            js.Execute();

            if (onerror != null) {
                foreach (var msg in js.Messages) {
                    if (msg.Type == JavaScript.Message.Types.Error) {
                        onerror(msg.Line + 1, msg.Column, msg.Content);
                    }
                }
            }

            return js.Get("result") as string;

        }
    }
}
