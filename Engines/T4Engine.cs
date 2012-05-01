
using System;
using EnvDTE;
using EnvDTE80;
using VSLangProj;

namespace Zippy.Chirp.Engines
{
    public class T4Engine : ActionEngine
    {
        private const string ControllerCSFile = ".cs";
        private const string ControllerVBFile = ".vb";
        private const string MVCViewFile = ".aspx";
        private const string MVCPartialViewFile = ".ascx";
        private const string RazorVBView = ".vbhtml";
        private const string RazorCSView = ".cshtml";

        private const string MVCT4TemplateName = "T4MVC.tt";

        private System.Threading.Timer tmr;

        public static void RunT4Template(DTE2 app, string t4TemplateList)
        {
            try
            {
                string[] t4List = t4TemplateList.Split(new char[] { ',' });
                foreach (string t4Template in t4List)
                {
                    ProjectItem projectItem = app.Solution.FindProjectItem(t4Template.Trim());
                    if (projectItem == null) continue;
                    VSProjectItem vsItem = projectItem.Object as VSProjectItem;
                    vsItem.RunCustomTool();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public override int Handles(string filename)
        {
            this.Settings = Settings.Instance(filename);
            return this.Settings.SmartRunT4MVC
                && (this.IsMVCStandardViewScriptOrContentFile(filename) || this.IsMVCStandardControllerFile(filename)) ? 1 : 0;
        }

        public override void Run(string fullFileName, ProjectItem projectItem)
        {
            if (this.tmr != null) 
            {
                this.tmr.Dispose(); 
            }

            this.tmr = new System.Threading.Timer((threadState) => RunT4Template(this.Chirp.App, MVCT4TemplateName), null, 1000, System.Threading.Timeout.Infinite);
        }

        private bool IsMVCStandardControllerFile(string fileName)
        {
            return (fileName.EndsWith(ControllerCSFile, StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(ControllerVBFile, StringComparison.OrdinalIgnoreCase)) &&
                                        fileName.Contains("Controller");
        }

        private bool IsMVCStandardViewScriptOrContentFile(string fileName)
        {
            return ((
                fileName.EndsWith(MVCViewFile, StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(MVCPartialViewFile, StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(RazorCSView, StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(RazorVBView, StringComparison.OrdinalIgnoreCase)) && fileName.Contains("Views")) || fileName.Contains("Scripts") || fileName.Contains("Content");
        }
    }
}
