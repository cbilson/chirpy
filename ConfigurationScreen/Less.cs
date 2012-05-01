using System;
using System.Windows.Forms;

namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class Less : BaseConfigurationControl
    {
        public Less()
        {
            this.InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            txtChirpLessFile.Text = this.Settings.ChirpLessFile;
            txtMichaelAshLessFile.Text = this.Settings.ChirpMichaelAshLessFile;
            txtHybridLessFile.Text = this.Settings.ChirpHybridLessFile;
            txtMSAjaxLessFile.Text = this.Settings.ChirpMSAjaxLessFile;
            chkCompress.Checked = this.Settings.DotLessCompress;
            chkSyntaxHighlight.Checked = this.Settings.LessSyntaxHighlighting;
        }

        public override void OnOK()
        {
            this.Settings.ChirpLessFile = txtChirpLessFile.Text;
            this.Settings.ChirpMichaelAshLessFile = txtMichaelAshLessFile.Text;
            this.Settings.ChirpHybridLessFile = txtHybridLessFile.Text;
            this.Settings.ChirpMSAjaxLessFile = txtMSAjaxLessFile.Text;
            this.Settings.DotLessCompress = chkCompress.Checked;
            this.Settings.LessSyntaxHighlighting=chkSyntaxHighlight.Checked;
            this.Settings.Save();
        }

        private void linkLabelModeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dotlesscss.org/");
        }
    }
}
