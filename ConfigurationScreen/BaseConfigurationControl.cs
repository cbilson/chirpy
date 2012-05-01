using System;
using System.Windows.Forms;

namespace Zippy.Chirp.ConfigurationScreen
{
    public class BaseConfigurationControl : UserControl, EnvDTE.IDTToolsOptionsPage
    {
        private Settings settings = Settings.Instance();

        public Settings Settings
        {
            get { return this.settings; }
        }

        public virtual void GetProperties(ref object propertiesObject)
        {
            propertiesObject = null;
        }

        public virtual void OnAfterCreated(EnvDTE.DTE dteObject)
        {
            throw new NotImplementedException();
        }

        public virtual void OnCancel()
        {
            throw new NotImplementedException();
        }

        public virtual void OnHelp()
        {
            System.Diagnostics.Process.Start("http://chirpy.codeplex.com/");
        }

        public virtual void OnOK()
        {
            throw new System.NotImplementedException();
        }
    }
}
