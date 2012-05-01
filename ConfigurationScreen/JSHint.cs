
namespace Zippy.Chirp.ConfigurationScreen
{
    public partial class JSHint : BaseConfigurationControl
    {
        public JSHint()
        {
            InitializeComponent();
        }

        public override void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            this.chkBitwise.Checked = this.Settings.JsHintOptions.bitwise;
            this.chkBoss.Checked = this.Settings.JsHintOptions.boss;
            this.chkCurly.Checked = this.Settings.JsHintOptions.curly;
            this.chkDebug.Checked = this.Settings.JsHintOptions.debug;
            this.chkEqeqeq.Checked = this.Settings.JsHintOptions.eqeqeq;
            this.chkEvil.Checked = this.Settings.JsHintOptions.evil;
            this.chkForin.Checked = this.Settings.JsHintOptions.forin;
            this.chkImmed.Checked = this.Settings.JsHintOptions.immed;
            this.chkLaxbreak.Checked = this.Settings.JsHintOptions.laxbreak;
            if (this.Settings.JsHintOptions.maxerr.HasValue)
            {
                this.TxtMaxerr.Value = this.Settings.JsHintOptions.maxerr.Value;
            }

            this.chkNewcap.Checked = this.Settings.JsHintOptions.newcapp;
            this.chkNoArg.Checked = this.Settings.JsHintOptions.noarg;
            this.chkNoEmpty.Checked = this.Settings.JsHintOptions.noempty;
            this.chkNomen.Checked = this.Settings.JsHintOptions.nomen;
            this.chkNoNew.Checked = this.Settings.JsHintOptions.nonew;
            this.chkNoVar.Checked = this.Settings.JsHintOptions.novar;
            this.chkPassfail.Checked = this.Settings.JsHintOptions.passfail;
            this.chkPlusPlus.Checked = this.Settings.JsHintOptions.plusplus;
            this.chkRegex.Checked = this.Settings.JsHintOptions.regex;
            this.chkStrict.Checked = this.Settings.JsHintOptions.strict;
            this.chkSub.Checked = this.Settings.JsHintOptions.sub;
            this.chkUndef.Checked = this.Settings.JsHintOptions.undef;
            this.chkWhite.Checked = this.Settings.JsHintOptions.white;
            this.chkJSHint.Checked = this.Settings.RunJSHint;
        }

        public override void OnOK()
        {
            this.Settings.JsHintOptions.devel = true;
            this.Settings.JsHintOptions.bitwise = this.chkBitwise.Checked;
            this.Settings.JsHintOptions.boss = this.chkBoss.Checked;
            this.Settings.JsHintOptions.curly = this.chkCurly.Checked;
            this.Settings.JsHintOptions.debug = this.chkDebug.Checked;
            this.Settings.JsHintOptions.eqeqeq = this.chkEqeqeq.Checked;
            this.Settings.JsHintOptions.evil = this.chkEvil.Checked;
            this.Settings.JsHintOptions.forin = this.chkForin.Checked;
            this.Settings.JsHintOptions.immed = this.chkImmed.Checked;
            this.Settings.JsHintOptions.laxbreak = this.chkLaxbreak.Checked;
            this.Settings.JsHintOptions.maxerr = (int)this.TxtMaxerr.Value;
            this.Settings.JsHintOptions.newcapp = this.chkNewcap.Checked;
            this.Settings.JsHintOptions.noarg = this.chkNoArg.Checked;
            this.Settings.JsHintOptions.noempty = this.chkNoEmpty.Checked;
            this.Settings.JsHintOptions.nomen = this.chkNomen.Checked;
            this.Settings.JsHintOptions.nonew = this.chkNoNew.Checked;
            this.Settings.JsHintOptions.novar = this.chkNoVar.Checked;
            this.Settings.JsHintOptions.passfail = this.chkPassfail.Checked;
            this.Settings.JsHintOptions.plusplus = this.chkPlusPlus.Checked;
            this.Settings.JsHintOptions.regex = this.chkRegex.Checked;
            this.Settings.JsHintOptions.strict = this.chkStrict.Checked;
            this.Settings.JsHintOptions.sub = this.chkSub.Checked;
            this.Settings.JsHintOptions.undef = this.chkUndef.Checked;
            this.Settings.JsHintOptions.white = this.chkWhite.Checked;
            this.Settings.RunJSHint = this.chkJSHint.Checked;
            this.Settings.Save();
        }

        private void linkLabelModeInfo_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.jshint.com/");
        }
    }
}
