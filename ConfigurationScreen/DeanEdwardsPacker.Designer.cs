namespace Zippy.Chirp.ConfigurationScreen
{
    partial class DeanEdwardsPacker
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
            this.linkLabelModeInfo = new System.Windows.Forms.LinkLabel();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboPackerEncoding = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSpecialChars = new System.Windows.Forms.CheckBox();
            this.chkFastDecode = new System.Windows.Forms.CheckBox();
            this.gbSetting.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabelModeInfo
            // 
            this.linkLabelModeInfo.AutoSize = true;
            this.linkLabelModeInfo.Location = new System.Drawing.Point(287, 12);
            this.linkLabelModeInfo.Name = "linkLabelModeInfo";
            this.linkLabelModeInfo.Size = new System.Drawing.Size(85, 13);
            this.linkLabelModeInfo.TabIndex = 31;
            this.linkLabelModeInfo.TabStop = true;
            this.linkLabelModeInfo.Text = "More information";
            this.linkLabelModeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModeInfo_LinkClicked);
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.panel2);
            this.gbSetting.Location = new System.Drawing.Point(3, 35);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(381, 252);
            this.gbSetting.TabIndex = 32;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Options";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.cboPackerEncoding);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.chkSpecialChars);
            this.panel2.Controls.Add(this.chkFastDecode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 233);
            this.panel2.TabIndex = 29;
            // 
            // cboPackerEncoding
            // 
            this.cboPackerEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPackerEncoding.FormattingEnabled = true;
            this.cboPackerEncoding.Items.AddRange(new object[] {
            "MultipleLines",
            "SingleLine"});
            this.cboPackerEncoding.Location = new System.Drawing.Point(61, 3);
            this.cboPackerEncoding.Name = "cboPackerEncoding";
            this.cboPackerEncoding.Size = new System.Drawing.Size(121, 21);
            this.cboPackerEncoding.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Encoding";
            // 
            // chkSpecialChars
            // 
            this.chkSpecialChars.AutoSize = true;
            this.chkSpecialChars.Location = new System.Drawing.Point(3, 55);
            this.chkSpecialChars.Name = "chkSpecialChars";
            this.chkSpecialChars.Size = new System.Drawing.Size(131, 17);
            this.chkSpecialChars.TabIndex = 1;
            this.chkSpecialChars.Text = "Replace special chars";
            this.chkSpecialChars.UseVisualStyleBackColor = true;
            // 
            // chkFastDecode
            // 
            this.chkFastDecode.AutoSize = true;
            this.chkFastDecode.Location = new System.Drawing.Point(3, 32);
            this.chkFastDecode.Name = "chkFastDecode";
            this.chkFastDecode.Size = new System.Drawing.Size(85, 17);
            this.chkFastDecode.TabIndex = 0;
            this.chkFastDecode.Text = "Fast decode";
            this.chkFastDecode.UseVisualStyleBackColor = true;
            // 
            // DeanEdwardsPacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.linkLabelModeInfo);
            this.Name = "DeanEdwardsPacker";
            this.Size = new System.Drawing.Size(387, 291);
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelModeInfo;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSpecialChars;
        private System.Windows.Forms.CheckBox chkFastDecode;
        private System.Windows.Forms.ComboBox cboPackerEncoding;
        private System.Windows.Forms.Label label5;

    }
}
