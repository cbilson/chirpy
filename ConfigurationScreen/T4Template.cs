using System;
using System.Windows.Forms;

namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class T4Template : BaseConfigurationControl
    {
        public T4Template()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
           this.chkT4RunOnBuild.Checked = this.Settings.T4RunAsBuild;
            this.txtT4RunAsBuildTemplate.Enabled = chkT4RunOnBuild.Checked;
            this.txtT4RunAsBuildTemplate.Text = this.Settings.T4RunAsBuildTemplate;
            this.chkSmartRunT4MVC.Checked = this.Settings.SmartRunT4MVC;
        }

        public override void OnOK()
        {
            this.Settings.T4RunAsBuild = this.chkT4RunOnBuild.Checked;
            this.Settings.T4RunAsBuildTemplate = this.txtT4RunAsBuildTemplate.Text;
            this.Settings.SmartRunT4MVC = this.chkSmartRunT4MVC.Checked;
            this.Settings.Save();
        }

        private void T4RunOnBuild_CheckedChanged(object sender, EventArgs e)
        {
            this.txtT4RunAsBuildTemplate.Enabled = this.chkT4RunOnBuild.Checked;
        }
    }
}
