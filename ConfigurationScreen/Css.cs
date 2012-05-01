
namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class Css : BaseConfigurationControl
    {
        public Css()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            this.txtChirpCssFile.Text = this.Settings.ChirpCssFile;
            this.txtMichaelAshCssFile.Text = this.Settings.ChirpMichaelAshCssFile;
            this.txtHybridCssFile.Text = this.Settings.ChirpHybridCssFile;
            this.txtMSAjaxCssFile.Text = this.Settings.ChirpMSAjaxCssFile;
            this.txtOutputExtension.Text = this.Settings.OutputExtensionCSS;
        }

        public override void OnOK()
        {
            this.Settings.ChirpCssFile = this.txtChirpCssFile.Text;
            this.Settings.ChirpMichaelAshCssFile = this.txtMichaelAshCssFile.Text;
            this.Settings.ChirpHybridCssFile = this.txtHybridCssFile.Text;
            this.Settings.ChirpMSAjaxCssFile = this.txtMSAjaxCssFile.Text;
            this.Settings.OutputExtensionCSS = this.txtOutputExtension.Text;
            this.Settings.Save();
        }
    }
}
