using System;
using System.Windows.Forms;

namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class CoffeeScript : BaseConfigurationControl
    {
        public CoffeeScript()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            txtChirpJsFile.Text = this.Settings.ChirpCoffeeScriptFile;
            txtChirpSimpleJsFile.Text = this.Settings.ChirpSimpleCoffeeScriptFile;
            txtChirpWhiteSpaceJsFile.Text = this.Settings.ChirpWhiteSpaceCoffeeScriptFile;
            txtChirpYUIJsFile.Text = this.Settings.ChirpYUICoffeeScriptFile;
            txtMSAjaxJsFile.Text = this.Settings.ChirpMSAjaxCoffeeScriptFile;

            chkBare.Checked = this.Settings.CoffeeScriptOptions.bare;
        }

        public override void OnOK()
        {
            this.Settings.ChirpCoffeeScriptFile = txtChirpJsFile.Text;
            this.Settings.ChirpSimpleCoffeeScriptFile = txtChirpSimpleJsFile.Text;
            this.Settings.ChirpWhiteSpaceCoffeeScriptFile = txtChirpWhiteSpaceJsFile.Text;
            this.Settings.ChirpYUICoffeeScriptFile = txtChirpYUIJsFile.Text;
            this.Settings.ChirpMSAjaxCoffeeScriptFile = txtMSAjaxJsFile.Text;

            this.Settings.CoffeeScriptOptions.bare = chkBare.Checked;

            this.Settings.Save();
        }

        private void linkLabelModeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://jashkenas.github.com/coffee-script/");
        }

    }
}
