using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zippy.Chirp
{
    public partial class ConfigurationScreen : UserControl, EnvDTE.IDTToolsOptionsPage
    {
        public ConfigurationScreen()
        {
            InitializeComponent();
        }


        #region IDTToolsOptionsPage Members
        void EnvDTE.IDTToolsOptionsPage.GetProperties(ref object PropertiesObject)
        {
            PropertiesObject = null;
        }

        void EnvDTE.IDTToolsOptionsPage.OnAfterCreated(EnvDTE.DTE DTEObject)
        {
            Settings.Load();
            txtChirpConfigFile.Text = Settings.ChirpConfigFile;
            txtChirpCssFile.Text = Settings.ChirpCssFile;
            txtMichaelAshCssFile.Text = Settings.ChirpMichaelAshCssFile;
            txtHybridCssFile.Text = Settings.ChirpHybridCssFile;
            txtChirpJsFile.Text = Settings.ChirpJsFile;
            txtChirpLessFile.Text = Settings.ChirpLessFile;
            txtChirpSimpleJsFile.Text = Settings.ChirpSimpleJsFile;
            txtChirpWhiteSpaceJsFile.Text = Settings.ChirpWhiteSpaceJsFile;
            txtChirpYUIJsFile.Text = Settings.ChirpYUIJsFile;
            chkT4RunOnBuild.Checked = Settings.T4RunAsBuild;
            txtT4RunAsBuildTemplate.Enabled = chkT4RunOnBuild.Checked;
            txtT4RunAsBuildTemplate.Text=Settings.T4RunAsBuildTemplate;
            chkSmartRunT4MVC.Checked = Settings.SmartRunT4MVC;
        }

        void EnvDTE.IDTToolsOptionsPage.OnCancel()
        {
            
        }

        void EnvDTE.IDTToolsOptionsPage.OnHelp()
        {
            
        }

        void EnvDTE.IDTToolsOptionsPage.OnOK()
        {
            Settings.ChirpConfigFile=txtChirpConfigFile.Text;
            Settings.ChirpCssFile=txtChirpCssFile.Text;
            Settings.ChirpMichaelAshCssFile=txtMichaelAshCssFile.Text;
            Settings.ChirpHybridCssFile = txtHybridCssFile.Text;
            Settings.ChirpJsFile=txtChirpJsFile.Text;
            Settings.ChirpLessFile=txtChirpLessFile.Text;
            Settings.ChirpSimpleJsFile=txtChirpSimpleJsFile.Text;
            Settings.ChirpWhiteSpaceJsFile=txtChirpWhiteSpaceJsFile.Text;
            Settings.ChirpYUIJsFile=txtChirpYUIJsFile.Text;
            Settings.T4RunAsBuild=chkT4RunOnBuild.Checked;
            Settings.T4RunAsBuildTemplate = txtT4RunAsBuildTemplate.Text;
            Settings.SmartRunT4MVC = chkSmartRunT4MVC.Checked;
            Settings.Save();
        }
        #endregion

        private void chkT4RunOnBuild_CheckedChanged(object sender, EventArgs e)
        {
            txtT4RunAsBuildTemplate.Enabled = chkT4RunOnBuild.Checked;
        }

       
    }
}
