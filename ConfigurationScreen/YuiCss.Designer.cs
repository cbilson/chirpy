namespace Zippy.Chirp.ConfigurationScreen
{
    partial class YuiCss
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtColumnWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRemoveComments = new System.Windows.Forms.CheckBox();
            this.gbSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtColumnWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelModeInfo
            // 
            this.linkLabelModeInfo.AutoSize = true;
            this.linkLabelModeInfo.Location = new System.Drawing.Point(287, 12);
            this.linkLabelModeInfo.Name = "linkLabelModeInfo";
            this.linkLabelModeInfo.Size = new System.Drawing.Size(85, 13);
            this.linkLabelModeInfo.TabIndex = 33;
            this.linkLabelModeInfo.TabStop = true;
            this.linkLabelModeInfo.Text = "More information";
            this.linkLabelModeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModeInfo_LinkClicked);
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.panel1);
            this.gbSetting.Location = new System.Drawing.Point(3, 28);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(381, 260);
            this.gbSetting.TabIndex = 34;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txtColumnWidth);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkRemoveComments);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 241);
            this.panel1.TabIndex = 29;
            // 
            // txtColumnWidth
            // 
            this.txtColumnWidth.Location = new System.Drawing.Point(85, 21);
            this.txtColumnWidth.Name = "txtColumnWidth";
            this.txtColumnWidth.Size = new System.Drawing.Size(42, 20);
            this.txtColumnWidth.TabIndex = 29;
            this.txtColumnWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Column width";
            // 
            // chkRemoveComments
            // 
            this.chkRemoveComments.AutoSize = true;
            this.chkRemoveComments.Location = new System.Drawing.Point(5, 3);
            this.chkRemoveComments.Name = "chkRemoveComments";
            this.chkRemoveComments.Size = new System.Drawing.Size(117, 17);
            this.chkRemoveComments.TabIndex = 0;
            this.chkRemoveComments.Text = "Remove comments";
            this.chkRemoveComments.UseVisualStyleBackColor = true;
            // 
            // YuiCss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.linkLabelModeInfo);
            this.Name = "YuiCss";
            this.Size = new System.Drawing.Size(387, 291);
            this.gbSetting.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtColumnWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelModeInfo;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown txtColumnWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRemoveComments;
    }
}
