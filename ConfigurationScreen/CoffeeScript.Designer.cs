namespace Zippy.Chirp.ConfigurationScreen
{
    partial class CoffeeScript
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtMSAjaxJsFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChirpJsFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChirpSimpleJsFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChirpWhiteSpaceJsFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChirpYUIJsFile = new System.Windows.Forms.TextBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBare = new System.Windows.Forms.CheckBox();
            this.linkLabelModeInfo = new System.Windows.Forms.LinkLabel();
            this.gbSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Microsoft Ajax Minifier :";
            // 
            // txtMSAjaxJsFile
            // 
            this.txtMSAjaxJsFile.Location = new System.Drawing.Point(183, 146);
            this.txtMSAjaxJsFile.Name = "txtMSAjaxJsFile";
            this.txtMSAjaxJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtMSAjaxJsFile.TabIndex = 21;
            this.txtMSAjaxJsFile.Text = ".MSAjax.js";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Closure Compiler - Advanced :";
            // 
            // txtChirpJsFile
            // 
            this.txtChirpJsFile.Location = new System.Drawing.Point(183, 42);
            this.txtChirpJsFile.Name = "txtChirpJsFile";
            this.txtChirpJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpJsFile.TabIndex = 1;
            this.txtChirpJsFile.Tag = "ChipJsGctFile";
            this.txtChirpJsFile.Text = ".gct.js";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Closure Compiler - Simple :";
            // 
            // txtChirpSimpleJsFile
            // 
            this.txtChirpSimpleJsFile.Location = new System.Drawing.Point(183, 68);
            this.txtChirpSimpleJsFile.Name = "txtChirpSimpleJsFile";
            this.txtChirpSimpleJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpSimpleJsFile.TabIndex = 3;
            this.txtChirpSimpleJsFile.Text = ".simple.js";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Closure Compiler - Whitespace only :";
            // 
            // txtChirpWhiteSpaceJsFile
            // 
            this.txtChirpWhiteSpaceJsFile.Location = new System.Drawing.Point(183, 94);
            this.txtChirpWhiteSpaceJsFile.Name = "txtChirpWhiteSpaceJsFile";
            this.txtChirpWhiteSpaceJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpWhiteSpaceJsFile.TabIndex = 5;
            this.txtChirpWhiteSpaceJsFile.Text = ".whitespace.js";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "YUI Compressor :";
            // 
            // txtChirpYUIJsFile
            // 
            this.txtChirpYUIJsFile.Location = new System.Drawing.Point(183, 120);
            this.txtChirpYUIJsFile.Name = "txtChirpYUIJsFile";
            this.txtChirpYUIJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpYUIJsFile.TabIndex = 7;
            this.txtChirpYUIJsFile.Text = ".yui.js";
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.panel1);
            this.gbSetting.Location = new System.Drawing.Point(3, 179);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(381, 71);
            this.gbSetting.TabIndex = 29;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkBare);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 52);
            this.panel1.TabIndex = 29;
            // 
            // chkBare
            // 
            this.chkBare.AutoSize = true;
            this.chkBare.Location = new System.Drawing.Point(3, 3);
            this.chkBare.Name = "chkBare";
            this.chkBare.Size = new System.Drawing.Size(345, 17);
            this.chkBare.TabIndex = 0;
            this.chkBare.Text = "Compile the JavaScript without the top-level function safety wrapper";
            this.chkBare.UseVisualStyleBackColor = true;
            // 
            // linkLabelModeInfo
            // 
            this.linkLabelModeInfo.AutoSize = true;
            this.linkLabelModeInfo.Location = new System.Drawing.Point(287, 12);
            this.linkLabelModeInfo.Name = "linkLabelModeInfo";
            this.linkLabelModeInfo.Size = new System.Drawing.Size(85, 13);
            this.linkLabelModeInfo.TabIndex = 34;
            this.linkLabelModeInfo.TabStop = true;
            this.linkLabelModeInfo.Text = "More information";
            this.linkLabelModeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModeInfo_LinkClicked);
            // 
            // CoffeeScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelModeInfo);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMSAjaxJsFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChirpJsFile);
            this.Controls.Add(this.txtChirpYUIJsFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtChirpSimpleJsFile);
            this.Controls.Add(this.txtChirpWhiteSpaceJsFile);
            this.Controls.Add(this.label3);
            this.Name = "CoffeeScript";
            this.Size = new System.Drawing.Size(387, 253);
            this.gbSetting.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMSAjaxJsFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChirpJsFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChirpSimpleJsFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChirpWhiteSpaceJsFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChirpYUIJsFile;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkBare;
        private System.Windows.Forms.LinkLabel linkLabelModeInfo;

    }
}
