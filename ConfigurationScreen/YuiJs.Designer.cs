namespace Zippy.Chirp.ConfigurationScreen
{
    partial class YuiJs
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
            this.txtLineBreakPosition = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDisableOptimizations = new System.Windows.Forms.CheckBox();
            this.chkIsObfuscateJavascript = new System.Windows.Forms.CheckBox();
            this.chkPreserveAllSemiColons = new System.Windows.Forms.CheckBox();
            this.gbSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineBreakPosition)).BeginInit();
            this.SuspendLayout();
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
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.panel1);
            this.gbSetting.Location = new System.Drawing.Point(0, 32);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(384, 256);
            this.gbSetting.TabIndex = 35;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkPreserveAllSemiColons);
            this.panel1.Controls.Add(this.chkIsObfuscateJavascript);
            this.panel1.Controls.Add(this.txtLineBreakPosition);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkDisableOptimizations);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 237);
            this.panel1.TabIndex = 29;
            // 
            // txtLineBreakPosition
            // 
            this.txtLineBreakPosition.Location = new System.Drawing.Point(105, 48);
            this.txtLineBreakPosition.Name = "txtLineBreakPosition";
            this.txtLineBreakPosition.Size = new System.Drawing.Size(42, 20);
            this.txtLineBreakPosition.TabIndex = 29;
            this.txtLineBreakPosition.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Line Break position";
            // 
            // chkDisableOptimizations
            // 
            this.chkDisableOptimizations.AutoSize = true;
            this.chkDisableOptimizations.Location = new System.Drawing.Point(5, 3);
            this.chkDisableOptimizations.Name = "chkDisableOptimizations";
            this.chkDisableOptimizations.Size = new System.Drawing.Size(124, 17);
            this.chkDisableOptimizations.TabIndex = 0;
            this.chkDisableOptimizations.Text = "Disable optimizations";
            this.chkDisableOptimizations.UseVisualStyleBackColor = true;
            // 
            // chkIsObfuscateJavascript
            // 
            this.chkIsObfuscateJavascript.AutoSize = true;
            this.chkIsObfuscateJavascript.Location = new System.Drawing.Point(5, 26);
            this.chkIsObfuscateJavascript.Name = "chkIsObfuscateJavascript";
            this.chkIsObfuscateJavascript.Size = new System.Drawing.Size(132, 17);
            this.chkIsObfuscateJavascript.TabIndex = 30;
            this.chkIsObfuscateJavascript.Text = "Is obfuscate javascript";
            this.chkIsObfuscateJavascript.UseVisualStyleBackColor = true;
            // 
            // chkPreserveAllSemiColons
            // 
            this.chkPreserveAllSemiColons.AutoSize = true;
            this.chkPreserveAllSemiColons.Location = new System.Drawing.Point(5, 74);
            this.chkPreserveAllSemiColons.Name = "chkPreserveAllSemiColons";
            this.chkPreserveAllSemiColons.Size = new System.Drawing.Size(136, 17);
            this.chkPreserveAllSemiColons.TabIndex = 31;
            this.chkPreserveAllSemiColons.Text = "Preserve all semicolons";
            this.chkPreserveAllSemiColons.UseVisualStyleBackColor = true;
            // 
            // YuiJs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.linkLabelModeInfo);
            this.Name = "YuiJs";
            this.Size = new System.Drawing.Size(387, 291);
            this.gbSetting.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineBreakPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelModeInfo;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown txtLineBreakPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDisableOptimizations;
        private System.Windows.Forms.CheckBox chkIsObfuscateJavascript;
        private System.Windows.Forms.CheckBox chkPreserveAllSemiColons;
    }
}
