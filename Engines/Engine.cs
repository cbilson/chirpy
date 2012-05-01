using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EnvDTE;
using Zippy.Chirp.Manager;
using Zippy.Chirp.Xml;

namespace Zippy.Chirp.Engines
{
    public abstract class JsEngine : TransformEngine
    {
        public static string Minify(string fullFileName, string outputText, ProjectItem projectItem, MinifyType mode)
        {
            return Minify(fullFileName, outputText, projectItem, mode, string.Empty);
        }

        public static string Minify(string fullFileName, string outputText, ProjectItem projectItem, MinifyType mode,string customArgument)
        {
            if (mode == MinifyType.Unspecified)
            {
                mode = Settings.Instance(fullFileName).DefaultJavaScriptMinifier;
            }

            switch (mode)
            {
                case MinifyType.gctAdvanced:
                    return ClosureCompilerEngine.Minify(fullFileName, outputText, projectItem, ClosureCompilerCompressMode.ADVANCED_OPTIMIZATIONS, customArgument);
                case MinifyType.gctSimple:
                    return ClosureCompilerEngine.Minify(fullFileName, outputText, projectItem, ClosureCompilerCompressMode.SIMPLE_OPTIMIZATIONS, customArgument);
                case MinifyType.gctWhiteSpaceOnly:
                    return ClosureCompilerEngine.Minify(fullFileName, outputText, projectItem, ClosureCompilerCompressMode.WHITESPACE_ONLY, customArgument);
                case MinifyType.msAjax:
                    return MsJsEngine.Minify(fullFileName, outputText, projectItem);
                case MinifyType.uglify:
                    return UglifyEngine.Minify(fullFileName, outputText, projectItem);
                case MinifyType.jsBeautifier:
                    return UglifyEngine.Beautify(outputText);
                default:
                    return YuiJsEngine.Minify(fullFileName, outputText, projectItem);
            }
        }
    }

    public abstract class CssEngine : TransformEngine
    {
        public static string Minify(string fullFileName, string outputText, ProjectItem projectItem, MinifyType mode)
        {
            if (mode == MinifyType.Unspecified)
            {
                mode = Settings.Instance(fullFileName).DefaultCssMinifier; 
            }

            switch (mode)
            {
                case MinifyType.msAjax:
                    return MsCssEngine.Minify(fullFileName, outputText, projectItem);
                case MinifyType.yui:
                case MinifyType.yuiMARE:
                case MinifyType.yuiHybrid:
                default:
                    return YuiCssEngine.Minify(outputText, mode);
            }
        }
    }

    /// <summary>
    /// Performs some action on a ProjectItem
    /// </summary>
    public abstract class ActionEngine : IDisposable
    {
        private Settings _settings = new Settings();
        public Settings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        internal Chirp Chirp;

        /// <summary>
        /// Determines whether this action hands the specified file.  Returns an int to specify the priority--0 being not handled.
        /// </summary>
        /// <param name="fullFileName">file full name</param>
        /// <returns>Handle id</returns>
        public abstract int Handles(string fullFileName);

        public virtual void Run(string fullFileName, ProjectItem projectItem)
        {
            Settings = new Settings(System.IO.Path.GetDirectoryName(fullFileName));
        }

        public virtual void Dispose() 
        { 
        }
    }

    /// <summary>
    /// Transforms the contents of a file
    /// </summary>
    public abstract class TransformEngine : ActionEngine
    {
        public string OutputExtension { get; set; }

        public string[] Extensions { get; set; }

        public virtual string GetOutputExtension(string fullFileName)
        {
            return this.OutputExtension;
        }

        public abstract string Transform(string fullFileName, string text, ProjectItem projectItem);

        public override int Handles(string fullFileName)
        {
            if (fullFileName.EndsWith(this.GetOutputExtension(fullFileName), StringComparison.InvariantCultureIgnoreCase)) 
            { 
                return 0; 
            }

            var match = this.Extensions.Where(x => fullFileName.EndsWith(x, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault() ?? string.Empty;
            return match.Length;
        }

        public override void Run(string fullFileName, ProjectItem projectItem)
        {
            using (var manager = new VSProjectItemManager(this.Chirp.App, projectItem))
            {
                string baseFileName = Utilities.GetBaseFileName(fullFileName, this.Extensions);
                string inputText = System.IO.File.ReadAllText(fullFileName);
                string outputText = this.Transform(fullFileName, inputText, projectItem);
                this.Process(manager, fullFileName, projectItem, baseFileName, outputText);
            }
        }

        public virtual void Process(VSProjectItemManager manager, string fullFileName, ProjectItem projectItem, string baseFileName, string outputText)
        {
            if (manager != null)
            {
                manager.AddFileByFileName(baseFileName + this.GetOutputExtension(fullFileName), outputText);
            }
        }
    }

    public class EngineManager : Zippy.Chirp.Threading.ServiceQueue<ProjectItem>
    {
        private List<ActionEngine> allActions = new List<ActionEngine>();
        private TransformEngine[] transformers = new TransformEngine[0];
        private ActionEngine[] actions = new ActionEngine[0];
        private Chirp chirp;
        private ActionEngine configEngine;

        public EngineManager(Chirp chirp)
        {
            this.chirp = chirp;
        }

        public bool IsHandled(string fullFileName)
        {
            return this.actions.Any(x => x.Handles(fullFileName) > 0);
        }

        public bool IsHandledWithoutHint(string fullFileName)
        {
            return this.actions.Any(x => (x.Handles(fullFileName)> 0 && !(x is JSHintEngine) && !(x is CSSLintEngine)));
        }

        public bool IsTransformed(string fullFileName)
        {
            return this.transformers.Any(x => x.Handles(fullFileName) > 0)
                || (this.configEngine != null && this.configEngine.Handles(fullFileName) > 0);
        }

        /// <summary>
        /// Add a new ProjectItem processor
        /// </summary>
        /// <param name="action">action engine</param>
        public void Add(ActionEngine action)
        {
            action.Chirp = this.chirp;
            this.allActions.Add(action);
            this.actions = this.allActions.ToArray();
            this.transformers = this.allActions.OfType<TransformEngine>().ToArray();
            if (action is ConfigEngine)
            {
                this.configEngine = action;
            }
        }

        /// <summary>
        /// Remove all actions
        /// </summary>
        public void Clear()
        {
            foreach (var action in this.allActions)
            {
                try
                {
                    action.Dispose();
                }
                catch (Exception) 
                {
                }
            }

            this.allActions.Clear();
            this.actions = new ActionEngine[0];
            this.transformers = new TransformEngine[0];
        }

        public override void Enqueue(ProjectItem projectItem)
        {
            var parent = projectItem.GetParent();
            if (parent != null && !parent.IsFolder() && this.IsTransformed(parent.FileName()))
            {
                return;
            }

            var file = projectItem.FileName();

            if (!Any(i => i.FileName().Is(file)))
            {
                base.Enqueue(projectItem);
            }
        }

        protected override void Process(ProjectItem projectItem)
        {
            var fullFileName = projectItem.FileName();

            bool detailLog = false;
            List<ActionEngine> actions = null;
            try
            {
                detailLog = Settings.Instance(fullFileName).ShowDetailLog;
                TaskList.Instance.Remove(fullFileName);

                actions = this.allActions.Select(x => new { action = x, priority = x.Handles(fullFileName) })
                    .OrderByDescending(x => x.priority).Where(x => x.priority > 0).Select(x => x.action).ToList();
            }
            catch (System.Exception errorThrow)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Error: {0}. See output window for details.", errorThrow.Message));
                this.chirp.OutputWindowPane.OutputString(string.Format("Error: {0}\r\n", errorThrow));
            }

            if (detailLog)
            {
                this.chirp.OutputWindowPane.OutputString("Action found " + actions.Count().ToString() + " -- " + fullFileName + "\r\n");
            }

            bool transformed = false;
            foreach (var action in actions)
            {
                if (action is TransformEngine)
                {
                    if (transformed)
                    {
                        continue;
                    }

                    transformed = true;
                }

                if (detailLog)
                {
                    this.chirp.OutputWindowPane.OutputString(action.GetType().Name + " -- starting " + fullFileName + "\r\n");
                }

                try
                {
                    action.Run(fullFileName, projectItem);
                }
                catch (System.Exception errorThrow)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Error: {0}. See output window for details.", errorThrow.Message));
                    this.chirp.OutputWindowPane.OutputString(string.Format("Error: {0}\r\n", errorThrow));
                }

                if (detailLog)
                {
                    this.chirp.OutputWindowPane.OutputString(action.GetType().Name + " -- finished " + fullFileName + "\r\n");
                }

                if (TaskList.Instance.HasErrors(fullFileName))
                {
                    break;
                }
            }

            this.chirp.ConfigEngine.CheckForConfigRefresh(projectItem);
        }

        protected override void Error(ProjectItem projectItem, Exception ex)
        {
            if (ex is COMException || ex is System.Threading.ThreadAbortException)
            {
                return;
            }

            if (projectItem != null)
            {
                TaskList.Instance.Add(projectItem.ContainingProject, Microsoft.VisualStudio.Shell.TaskErrorCategory.Error, projectItem.FileName(), 1, 1, ex.ToString());
            }
            else
            {
                this.chirp.OutputWindowPane.OutputString(ex.ToString() + Environment.NewLine);
            }
        }
    }
}
