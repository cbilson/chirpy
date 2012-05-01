namespace Zippy.Chirp.ConfigurationScreen
{
    partial class Config
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.txtChirpConfigFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbJavaScript = new System.Windows.Forms.ComboBox();
            this.cmbCss = new System.Windows.Forms.ComboBox();
            this.chkShowDetailLog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Config :";
            // 
            // txtChirpConfigFile
            // 
            this.txtChirpConfigFile.Location = new System.Drawing.Point(198, 14);
            this.txtChirpConfigFile.Name = "txtChirpConfigFile";
            this.txtChirpConfigFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpConfigFile.TabIndex = 15;
            this.txtChirpConfigFile.Text = ".chirp.config";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Default JavaScript Minifier :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Default CSS Minifier :";
            // 
            // cmbJavaScript
            // 
            this.cmbJavaScript.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJavaScript.DropDownWidth = 200;
            this.cmbJavaScript.FormattingEnabled = true;
            this.cmbJavaScript.Location = new System.Drawing.Point(198, 40);
            this.cmbJavaScript.Name = "cmbJavaScript";
            this.cmbJavaScript.Size = new System.Drawing.Size(121, 21);
            this.cmbJavaScript.TabIndex = 19;
            // 
            // cmbCss
            // 
            this.cmbCss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCss.DropDownWidth = 200;
            this.cmbCss.FormattingEnabled = true;
            this.cmbCss.Location = new System.Drawing.Point(198, 66);
            this.cmbCss.Name = "cmbCss";
            this.cmbCss.Size = new System.Drawing.Size(121, 21);
            this.cmbCss.TabIndex = 20;
            // 
            // chkShowDetailLog
            // 
            this.chkShowDetailLog.AutoSize = true;
            this.chkShowDetailLog.Location = new System.Drawing.Point(198, 93);
            this.chkShowDetailLog.Name = "chkShowDetailLog";
            this.chkShowDetailLog.Size = new System.Drawing.Size(98, 17);
            this.chkShowDetailLog.TabIndex = 26;
            this.chkShowDetailLog.Text = "Show detail log";
            this.chkShowDetailLog.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkShowDetailLog);
            this.Controls.Add(this.cmbCss);
            this.Controls.Add(this.cmbJavaScript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtChirpConfigFile);
            this.Name = "Config";
            this.Size = new System.Drawing.Size(481, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtChirpConfigFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbJavaScript;
        private System.Windows.Forms.ComboBox cmbCss;
        private System.Windows.Forms.CheckBox chkShowDetailLog;
    }
}
