using System;
using System.Windows.Forms;

namespace Zippy.Chirp.ConfigurationScreen 
{
    public partial class Config : BaseConfigurationControl
    {
        public Config() 
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            this.chkShowDetailLog.Checked = this.Settings.ShowDetailLog;
            this.txtChirpConfigFile.Text = this.Settings.ChirpConfigFile;

            this.cmbCss.Items.Clear();
            this.cmbCss.Items.Add(Xml.MinifyType.msAjax.Description());
            this.cmbCss.Items.Add(Xml.MinifyType.yui.Description());
            this.cmbCss.Items.Add(Xml.MinifyType.yuiHybrid.Description());
            this.cmbCss.Items.Add(Xml.MinifyType.yuiMARE.Description());
            this.cmbCss.Text = this.Settings.DefaultCssMinifier.Description();

            this.cmbJavaScript.Items.Clear();
            this.cmbJavaScript.Items.Add(Xml.MinifyType.msAjax.Description());
            this.cmbJavaScript.Items.Add(Xml.MinifyType.yui.Description());
            this.cmbJavaScript.Items.Add(Xml.MinifyType.gctAdvanced.Description());
            this.cmbJavaScript.Items.Add(Xml.MinifyType.gctSimple.Description());
            this.cmbJavaScript.Items.Add(Xml.MinifyType.gctWhiteSpaceOnly.Description());
            this.cmbJavaScript.Items.Add(Xml.MinifyType.uglify.Description());
            this.cmbJavaScript.Text = this.Settings.DefaultJavaScriptMinifier.Description();
        }

        public override void OnOK() 
        {
            this.Settings.ShowDetailLog = this.chkShowDetailLog.Checked;
            this.Settings.ChirpConfigFile = this.txtChirpConfigFile.Text;
            this.Settings.DefaultCssMinifier = this.cmbCss.Text.ToEnum(Xml.MinifyType.Unspecified);
            this.Settings.DefaultJavaScriptMinifier = this.cmbJavaScript.Text.ToEnum(Xml.MinifyType.Unspecified);
            this.Settings.Save();
        }
    }
}
