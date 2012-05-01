
using Microsoft.Ajax.Utilities;
namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class MsCss : BaseConfigurationControl
    {
        public MsCss()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            this.cboColorNames.DataSource = System.Enum.GetNames(typeof(CssColor));
            this.cboCommentMode.DataSource = System.Enum.GetNames(typeof(CssComment));
            this.cboOutputMode.DataSource = System.Enum.GetNames(typeof(OutputMode));

            this.chkAllowEmbeddedAspNetBlocks.Checked = this.Settings.MsCssSettings.AllowEmbeddedAspNetBlocks;
            this.cboColorNames.Text = this.Settings.MsCssSettings.ColorNames.ToString();
            this.cboCommentMode.Text = this.Settings.MsCssSettings.CommentMode.ToString();
            this.cboOutputMode.Text = this.Settings.MsCssSettings.OutputMode.ToString();
            this.txtIndentSpaces.Value = this.Settings.MsJsSettings.IndentSize;
            this.chkMinifyExpressions.Checked = this.Settings.MsCssSettings.MinifyExpressions;
            this.txtLineBreakThreshold.Value = this.Settings.MsCssSettings.LineBreakThreshold;
            this.chkTermSemicolons.Checked = this.Settings.MsCssSettings.TermSemicolons;
        }

        public override void OnOK()
        {
            this.Settings.MsCssSettings.AllowEmbeddedAspNetBlocks = this.chkAllowEmbeddedAspNetBlocks.Checked;
            this.Settings.MsCssSettings.ColorNames = this.cboColorNames.Text.ToEnum(CssColor.Strict);
            this.Settings.MsCssSettings.CommentMode = this.cboCommentMode.Text.ToEnum(CssComment.Important);
            this.Settings.MsCssSettings.OutputMode = this.cboOutputMode.Text.ToEnum(OutputMode.SingleLine);
            this.Settings.MsJsSettings.IndentSize = (int)txtIndentSpaces.Value;
            this.Settings.MsCssSettings.MinifyExpressions = this.chkMinifyExpressions.Checked;
            this.Settings.MsCssSettings.LineBreakThreshold = (int)this.txtLineBreakThreshold.Value;
            this.Settings.MsCssSettings.TermSemicolons = this.chkTermSemicolons.Checked;
            this.Settings.Save();

        }
        


        private void linkLabelModeInfo_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.asp.net/ajaxlibrary/AjaxMinDLL.ashx");
        }
    }
}
