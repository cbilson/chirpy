using System;
using Zippy.Chirp.JavaScript;

namespace Zippy.Chirp.Engines {
    public class CSSLintEngine : ActionEngine {
        private static JavaScript.CSSLint lint;

        public override int Handles(string fullFileName) {
            this.Settings = Settings.Instance(fullFileName);
            if (this.Settings.RunCSSLint && fullFileName.EndsWith(".css", StringComparison.OrdinalIgnoreCase)
                && !fullFileName.EndsWith(this.Settings.OutputExtensionCSS, StringComparison.OrdinalIgnoreCase)) {
                return 1;
            }

            return 0;
        }

        public override void Run(string fullFileName, EnvDTE.ProjectItem projectItem) {
            if (lint == null) {
                lock (JavaScript.Extensibility.Instance) {
                    if (lint == null) {
                        lint = new JavaScript.CSSLint();
                    }
                }
            }

            this.Settings = Settings.Instance(fullFileName);
            var code = System.IO.File.ReadAllText(fullFileName);
            var results = lint.CSSLINT(code, this.Settings.CssLintOptions);

            if (results != null && results.messages != null && results.messages.Length > 0) {
                foreach (var item in results.messages) {
                    TaskList.Instance.Add(projectItem.ContainingProject,
                        item.type == JavaScript.CSSLint.Message.types.error ? Microsoft.VisualStudio.Shell.TaskErrorCategory.Error
                            : item.type == JavaScript.CSSLint.Message.types.warning ? Microsoft.VisualStudio.Shell.TaskErrorCategory.Warning
                            : Microsoft.VisualStudio.Shell.TaskErrorCategory.Message,
                        fullFileName, item.line, item.col, item.message);
                }
            }
        }

        public override void Dispose() {
            Utilities.Dispose(ref lint);
        }
    }

    public class JSHintEngine : ActionEngine {
        public override int Handles(string fullFileName) {
            this.Settings = Settings.Instance(fullFileName);
            if (this.Settings.RunJSHint && fullFileName.EndsWith(".js", StringComparison.OrdinalIgnoreCase)
                && !fullFileName.EndsWith(this.Settings.OutputExtensionJS, StringComparison.OrdinalIgnoreCase)) {
                return 1;
            }

            return 0;
        }

        public override void Run(string fullFileName, EnvDTE.ProjectItem projectItem) {

            var code = System.IO.File.ReadAllText(fullFileName);

            var results = JSHint.JSHINT(code, this.Settings.JsHintOptions);

            if (results != null) {
                foreach (var item in results) {
                    if (item != null && projectItem.ContainingProject != null && TaskList.Instance != null) {
                        TaskList.Instance.Add(projectItem.ContainingProject, Microsoft.VisualStudio.Shell.TaskErrorCategory.Warning, fullFileName, item.line, item.character, item.reason);
                    }
                }
            }
        }

    }

    public class UglifyEngine : JsEngine {

        public UglifyEngine() {
            Extensions = new[] { this.Settings.ChirpUglifyJsFile };
            OutputExtension = this.Settings.OutputExtensionJS;
        }

        public static string Minify(string fullFileName, string text, EnvDTE.ProjectItem projectItem) {
            try {
                return Uglify.squeeze_it(text, (line, col, msg) => {
                    if (TaskList.Instance != null) {
                        TaskList.Instance.Add(projectItem.ContainingProject, Microsoft.VisualStudio.Shell.TaskErrorCategory.Error,
                         fullFileName, line, col, msg);
                    }
                });
            } catch (System.Exception ex) {
                if (TaskList.Instance != null) {
                    TaskList.Instance.Add(projectItem.ContainingProject, ex, fullFileName);
                }
                return null;
            }
        }

        public static string Beautify(string text) {
            return JavaScript.Beautify.js_beautify(text);
        }

        public override string Transform(string fullFileName, string text, EnvDTE.ProjectItem projectItem) {
            return Minify(fullFileName, text, projectItem);
        }

    }
}
