using System;
using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

//// http://www.mztools.com/articles/2008/MZ2008022.aspx

namespace Zippy.Chirp
{
    public class TaskList : IDisposable
    {
        private static TaskList instance;
        private ErrorListProvider listProvider;
        private ServiceProvider serviceProvider;
        private List<ErrorTask> tasks = new List<ErrorTask>();
        private DTE2 app;
        private Dictionary<ErrorTask, Project> taskProjects = new Dictionary<ErrorTask, Project>();

        public TaskList(object application)
        {
            instance = this;

            this.app = application as DTE2;
            var app = application as Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
            if (app != null)
            {
                this.serviceProvider = new ServiceProvider(app);
                this.listProvider = new ErrorListProvider(this.serviceProvider);
                this.listProvider.ProviderName = this.GetType().Assembly.FullName;
                this.listProvider.ProviderGuid = new Guid("F1415C4C-5D67-401F-A81C-71F0721BB6F0");
                this.listProvider.Show();
            }
        }

        public static TaskList Instance
        {
            get
            {
                return instance;
            }
        }

        public IEnumerable<ErrorTask> Errors
        {
            get
            {
                return this.tasks;
            }
        }

        public bool HasErrors(string fullFilename)
        {
            return this.tasks.Any(x => x.Document.Is(fullFilename));
        }

        public void Add(Project project, TaskErrorCategory category, string file, int line, int column, string description)
        {
            var task = new ErrorTask
            {
                ErrorCategory = category,
                Document = file,
                Line = Math.Max(line - 1, 0),
                Column = Math.Max(column - 1, 0),
                Text = description,
            };
            this.Add(project, task);
        }

        public void Add(Project project, Exception ex, string filename)
        {
            this.Add(project, TaskErrorCategory.Error, filename, 0, 0, ex.ToString());
        }

        public void Remove(string file)
        {
            // var tasks = listProvider.Tasks.Cast<ErrorTask>().Where(x => file.Is(x.Document)).ToArray();
            foreach (var task in this.tasks.Where(x => x.Document.Is(file)).ToArray())
            {
                this.Remove(task);
            }
        }

        public void Remove(Project project)
        {
            lock (this.taskProjects)
            {
                var tasks = this.taskProjects.Where(x => x.Value == project).Select(x => x.Key).ToArray();
                foreach (var task in tasks)
                {
                    this.Remove(task);
                }
            }
        }

        public void RemoveAll()
        {
            if (this.listProvider != null)
            {
                this.listProvider.Tasks.Clear();
            }

            this.tasks.Clear();
            this.taskProjects.Clear();
        }

        public void Dispose()
        {
            if (this.listProvider != null)
            {
                this.listProvider.Dispose();
            }

            if (this.serviceProvider != null)
            {
                this.serviceProvider.Dispose();
            }
        }

        private void Remove(ErrorTask task)
        {
            if (this.listProvider != null)
            {
                this.listProvider.Tasks.Remove(task);
            }

            this.tasks.Remove(task);
            lock (this.taskProjects)
            {
                if (this.taskProjects.ContainsKey(task))
                {
                    this.taskProjects.Remove(task);
                }
            }
        }

        private void Add(Project project, ErrorTask task)
        {
            IVsHierarchy hierarchy = null;
            if (project != null && this.serviceProvider != null)
            {
                var solution = this.serviceProvider.GetService(typeof(IVsSolution)) as IVsSolution;
                if (solution != null)
                {
                    solution.GetProjectOfUniqueName(project.UniqueName, out hierarchy);
                }
            }

            task.HierarchyItem = hierarchy;
            task.Navigate += new EventHandler(this.Task_Navigate);
            if (this.listProvider != null)
            {
                this.listProvider.Tasks.Add(task);
            }

            this.tasks.Add(task);

            if (project != null)
            {
                lock (this.taskProjects)
                {
                    this.taskProjects.Add(task, project);
                }
            }

            if (this.app != null && this.app.ToolWindows != null)
            {
                this.app.ToolWindows.ErrorList.Parent.Activate();
            }
        }

        private void Task_Navigate(object sender, EventArgs e)
        {
            var task = sender as ErrorTask;

            task.Line++;
            var result = this.listProvider.Navigate(task, new Guid(EnvDTE.Constants.vsViewKindCode));
            task.Line--;
        }
    }
}