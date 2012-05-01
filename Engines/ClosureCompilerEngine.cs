
using System;
using EnvDTE;

namespace Zippy.Chirp.Engines
{
    public class ClosureCompilerEngine : JsEngine
    {
        #region "constructor"
        public ClosureCompilerEngine()
        {
            Extensions = new[] { this.Settings.ChirpSimpleJsFile, this.Settings.ChirpWhiteSpaceJsFile, this.Settings.ChirpGctJsFile, this.Settings.ChirpJsFile };
            OutputExtension = this.Settings.OutputExtensionJS;
        }
        #endregion

        public static string Minify(string fullFileName, string text, ProjectItem projectItem, ClosureCompilerCompressMode mode, string customArgument)
        {
            string returnedCode = null;

            returnedCode = GoogleClosureCompiler.Compress(
                fullFileName,
                text,
                mode,
                (category, msg, line, col) =>
                {
                    if (TaskList.Instance == null)
                    {
                        Console.WriteLine(string.Format("{0}({1},{2}){3}", fullFileName, line.ToString(), col.ToString(), msg));
                    }
                    else
                    {
                        TaskList.Instance.Add(projectItem.ContainingProject, category, fullFileName, line, col, msg);
                    }
                },
                customArgument
                );

            return returnedCode;
        }

        public override string Transform(string fullFileName, string text, ProjectItem projectItem)
        {
            this.Settings = Settings.Instance(fullFileName);
            var mode = ClosureCompilerCompressMode.WHITESPACE_ONLY;
            if(fullFileName.EndsWith(this.Settings.ChirpGctJsFile, StringComparison.OrdinalIgnoreCase))
            { 
                mode=ClosureCompilerCompressMode.ADVANCED_OPTIMIZATIONS;
            }
            else if(fullFileName.EndsWith(this.Settings.ChirpJsFile, StringComparison.OrdinalIgnoreCase))
            { 
                mode=ClosureCompilerCompressMode.ADVANCED_OPTIMIZATIONS;
            }
            else if(fullFileName.EndsWith(this.Settings.ChirpSimpleJsFile, StringComparison.OrdinalIgnoreCase))
            {
                mode=ClosureCompilerCompressMode.SIMPLE_OPTIMIZATIONS;
            }
                  
            return Minify(fullFileName, text, projectItem, mode, string.Empty);
        }
    }
}
