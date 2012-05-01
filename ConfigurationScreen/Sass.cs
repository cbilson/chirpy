using System;
using System.Windows.Forms;

namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class Sass : BaseConfigurationControl
    {
        public Sass()
        {
            this.InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            txtChirpSassFile.Text = this.Settings.ChirpSassFile;
            txtMichaelAshSassFile.Text = this.Settings.ChirpMichaelAshSassFile;
            txtHybridSassFile.Text = this.Settings.ChirpHybridSassFile;
            txtMSAjaxSassFile.Text = this.Settings.ChirpMSAjaxSassFile;

            txtChirpScssFile.Text = this.Settings.ChirpScssFile;
            txtMichaelAshScssFile.Text = this.Settings.ChirpMichaelAshScssFile;
            txtHybridScssFile.Text = this.Settings.ChirpHybridScssFile;
            txtMSAjaxScssFile.Text = this.Settings.ChirpMSAjaxScssFile;
            
        }

        public override void OnOK()
        {
            this.Settings.ChirpSassFile = txtChirpSassFile.Text;
            this.Settings.ChirpMichaelAshSassFile = txtMichaelAshSassFile.Text;
            this.Settings.ChirpHybridSassFile = txtHybridSassFile.Text;
            this.Settings.ChirpMSAjaxSassFile = txtMSAjaxSassFile.Text;

            this.Settings.ChirpScssFile = txtChirpScssFile.Text;
            this.Settings.ChirpMichaelAshScssFile = txtMichaelAshScssFile.Text;
            this.Settings.ChirpHybridScssFile = txtHybridScssFile.Text;
            this.Settings.ChirpMSAjaxScssFile = txtMSAjaxScssFile.Text;
            
            this.Settings.Save();
        }

        private void linkLabelModeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://sass-lang.com/");
        }
    }
}
