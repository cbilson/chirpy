using System;
using EnvDTE;

namespace Zippy.Chirp
{
   public class EcmaScriptErrorReporter : EcmaScript.NET.ErrorReporter
    {
        private ProjectItem projectItem;
        private string fullFileName;

        public EcmaScriptErrorReporter(string fullFileName, ProjectItem projectItem)
        {
            this.fullFileName = fullFileName;
            this.projectItem = projectItem;
        }

        public void Error(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            if (TaskList.Instance == null)
            {
                Console.WriteLine(string.Format("{0}({1},{2}){3}", this.fullFileName, line.ToString(), lineOffset.ToString(), message));
            }
            else
            {
                TaskList.Instance.Add(this.projectItem.ContainingProject, Microsoft.VisualStudio.Shell.TaskErrorCategory.Error, this.fullFileName, line, lineOffset, message);
            }
        }

        public void Warning(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            // _Result.Warnings.Add(new Result.Error { Description = message, Line = line, Column = lineOffset });
        }

        public EcmaScript.NET.EcmaScriptRuntimeException RuntimeError(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            return new EcmaScript.NET.EcmaScriptRuntimeException(message, sourceName, line, lineSource, lineOffset);
        }
    }
}
