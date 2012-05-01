using System.Windows.Forms;

namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class YuiCss : BaseConfigurationControl
    {
        public YuiCss()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            txtColumnWidth.Value = this.Settings.YuiCssSettings.ColumnWidth;
            chkRemoveComments.Checked = this.Settings.YuiCssSettings.RemoveComments;
        }

        public override void OnOK()
        {
            this.Settings.YuiCssSettings.ColumnWidth = (int)txtColumnWidth.Value;
            this.Settings.YuiCssSettings.RemoveComments = chkRemoveComments.Checked;
            this.Settings.Save();
        }

        private void linkLabelModeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://developer.yahoo.com/yui/compressor/");
        }
    }
}
