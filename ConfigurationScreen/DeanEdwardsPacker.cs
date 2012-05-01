
namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class DeanEdwardsPacker : BaseConfigurationControl
    {
        public DeanEdwardsPacker()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            this.cboPackerEncoding.DataSource = System.Enum.GetNames(typeof(Dean.Edwards.ECMAScriptPacker.PackerEncoding));
            this.cboPackerEncoding.Text = this.Settings.ChirpDeanEdwardsPackerEncoding.ToString();
            this.chkFastDecode.Checked = this.Settings.ChirpDeanEdwardsPackerFastDecode;
            this.chkSpecialChars.Checked = this.Settings.ChirpDeanEdwardsPackerSpecialChars;
        }

        public override void OnOK()
        {
            this.Settings.ChirpDeanEdwardsPackerEncoding = this.cboPackerEncoding.Text.ToEnum(Dean.Edwards.ECMAScriptPacker.PackerEncoding.Normal);
            this.Settings.ChirpDeanEdwardsPackerFastDecode = chkFastDecode.Checked;
            this.Settings.ChirpDeanEdwardsPackerSpecialChars = chkSpecialChars.Checked;
            this.Settings.Save();

        }

        private void linkLabelModeInfo_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://dean.edwards.name/packer/");
        }
    }
}
