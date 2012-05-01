using System.Windows.Forms;

namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class YuiJs : BaseConfigurationControl
    {
        public YuiJs()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            chkDisableOptimizations.Checked = this.Settings.YuiJsSettings.DisableOptimizations;
            chkIsObfuscateJavascript.Checked = this.Settings.YuiJsSettings.IsObfuscateJavascript;
            txtLineBreakPosition.Value = this.Settings.YuiJsSettings.LineBreakPosition;
            chkPreserveAllSemiColons.Checked = this.Settings.YuiJsSettings.PreserveAllSemiColons;
        }

        public override void OnOK()
        {
            this.Settings.YuiJsSettings.DisableOptimizations = chkDisableOptimizations.Checked;
            this.Settings.YuiJsSettings.IsObfuscateJavascript = chkIsObfuscateJavascript.Checked;
            this.Settings.YuiJsSettings.LineBreakPosition = (int)txtLineBreakPosition.Value;
            this.Settings.YuiJsSettings.PreserveAllSemiColons = chkPreserveAllSemiColons.Checked;
            this.Settings.Save();
        }

        private void linkLabelModeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://developer.yahoo.com/yui/compressor/");
        }
    }
}
