
using System.Windows.Forms;
namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class CssLint : BaseConfigurationControl
    {
        public CssLint()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            chkCSSLint.Checked = this.Settings.RunCSSLint;

            chkAdjoiningClasses.Checked = this.Settings.CssLintOptions.AdjoiningClasses;
            chkBoxModel.Checked = this.Settings.CssLintOptions.BoxModel;
            chkCompatibleVendorPrefixes.Checked = this.Settings.CssLintOptions.CompatibleVendorPrefixes;
            chkDisplayPropertyGrouping.Checked = this.Settings.CssLintOptions.DisplayPropertyGrouping;
            chkDuplicateProperties.Checked = this.Settings.CssLintOptions.DuplicateProperties;
            chkEmptyRules.Checked = this.Settings.CssLintOptions.EmptyRules;
            chkFloats.Checked = this.Settings.CssLintOptions.Floats;
            chkFontFaces.Checked = this.Settings.CssLintOptions.FontFaces;
            chkFontSizes.Checked = this.Settings.CssLintOptions.FontSizes;
            chkGradients.Checked = this.Settings.CssLintOptions.Gradients;
            chkIds.Checked = this.Settings.CssLintOptions.Ids;
            chkImport.Checked = this.Settings.CssLintOptions.Import;
            chkImportant.Checked = this.Settings.CssLintOptions.Important;
            chkQualifiedHeadings.Checked = this.Settings.CssLintOptions.QualifiedHeadings;
            chkRegexSelectors.Checked = this.Settings.CssLintOptions.RegexSelectors;
            chkUniqueHeadings.Checked = this.Settings.CssLintOptions.UniqueHeadings;
            chkVendorPRefix.Checked = this.Settings.CssLintOptions.VendorPrefix;
            chkZeroUnits.Checked = this.Settings.CssLintOptions.ZeroUnits;

            chkUniqueHeadings.Checked = this.Settings.CssLintOptions.Import;
        }

        public override void OnOK()
        {
            this.Settings.RunCSSLint = chkCSSLint.Checked;

            this.Settings.CssLintOptions.AdjoiningClasses = chkAdjoiningClasses.Checked;
            this.Settings.CssLintOptions.BoxModel = chkBoxModel.Checked;
            this.Settings.CssLintOptions.CompatibleVendorPrefixes = chkCompatibleVendorPrefixes.Checked;
            this.Settings.CssLintOptions.DisplayPropertyGrouping = chkDisplayPropertyGrouping.Checked;
            this.Settings.CssLintOptions.DuplicateProperties = chkDuplicateProperties.Checked;
            this.Settings.CssLintOptions.EmptyRules = chkEmptyRules.Checked;
            this.Settings.CssLintOptions.Floats = chkFloats.Checked;
            this.Settings.CssLintOptions.FontFaces = chkFontFaces.Checked;
            this.Settings.CssLintOptions.FontSizes = chkFontSizes.Checked;
            this.Settings.CssLintOptions.Gradients = chkGradients.Checked;
            this.Settings.CssLintOptions.Ids = chkIds.Checked;
            this.Settings.CssLintOptions.Import = chkImport.Checked;
            this.Settings.CssLintOptions.Important = chkImportant.Checked;
            this.Settings.CssLintOptions.QualifiedHeadings = chkQualifiedHeadings.Checked;
            this.Settings.CssLintOptions.RegexSelectors = chkRegexSelectors.Checked;
            this.Settings.CssLintOptions.UniqueHeadings = chkUniqueHeadings.Checked;
            this.Settings.CssLintOptions.VendorPrefix = chkVendorPRefix.Checked;
            this.Settings.CssLintOptions.ZeroUnits = chkZeroUnits.Checked;

            this.Settings.Save();
        }

        private void linkLabelModeInfo_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://csslint.net/about.html#docs");
        }
    }
}
