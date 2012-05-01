namespace Zippy.Chirp.ConfigurationScreen
{
    partial class MsCss
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
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboOutputMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLineBreakThreshold = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIndentSpaces = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTermSemicolons = new System.Windows.Forms.CheckBox();
            this.chkMinifyExpressions = new System.Windows.Forms.CheckBox();
            this.chkExpandOutput = new System.Windows.Forms.CheckBox();
            this.cboCommentMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboColorNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAllowEmbeddedAspNetBlocks = new System.Windows.Forms.CheckBox();
            this.linkLabelModeInfo = new System.Windows.Forms.LinkLabel();
            this.gbSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineBreakThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndentSpaces)).BeginInit();
            this.SuspendLayout();
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
            this.gbSetting.TabIndex = 30;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.cboOutputMode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtLineBreakThreshold);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtIndentSpaces);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkTermSemicolons);
            this.panel1.Controls.Add(this.chkMinifyExpressions);
            this.panel1.Controls.Add(this.chkExpandOutput);
            this.panel1.Controls.Add(this.cboCommentMode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboColorNames);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkAllowEmbeddedAspNetBlocks);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 241);
            this.panel1.TabIndex = 29;
            // 
            // cboOutputMode
            // 
            this.cboOutputMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputMode.FormattingEnabled = true;
            this.cboOutputMode.Items.AddRange(new object[] {
            "MultipleLines",
            "SingleLine"});
            this.cboOutputMode.Location = new System.Drawing.Point(106, 196);
            this.cboOutputMode.Name = "cboOutputMode";
            this.cboOutputMode.Size = new System.Drawing.Size(121, 21);
            this.cboOutputMode.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "OutputMode";
            // 
            // txtLineBreakThreshold
            // 
            this.txtLineBreakThreshold.Location = new System.Drawing.Point(106, 151);
            this.txtLineBreakThreshold.Maximum = new decimal(new int[] {
            2147482647,
            0,
            0,
            0});
            this.txtLineBreakThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLineBreakThreshold.Name = "txtLineBreakThreshold";
            this.txtLineBreakThreshold.Size = new System.Drawing.Size(91, 20);
            this.txtLineBreakThreshold.TabIndex = 29;
            this.txtLineBreakThreshold.Value = new decimal(new int[] {
            2147482647,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Line break threshold";
            // 
            // txtIndentSpaces
            // 
            this.txtIndentSpaces.Location = new System.Drawing.Point(106, 125);
            this.txtIndentSpaces.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtIndentSpaces.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtIndentSpaces.Name = "txtIndentSpaces";
            this.txtIndentSpaces.Size = new System.Drawing.Size(91, 20);
            this.txtIndentSpaces.TabIndex = 27;
            this.txtIndentSpaces.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Indent spaces";
            // 
            // chkTermSemicolons
            // 
            this.chkTermSemicolons.AutoSize = true;
            this.chkTermSemicolons.Location = new System.Drawing.Point(5, 102);
            this.chkTermSemicolons.Name = "chkTermSemicolons";
            this.chkTermSemicolons.Size = new System.Drawing.Size(252, 17);
            this.chkTermSemicolons.TabIndex = 7;
            this.chkTermSemicolons.Text = "Forces all rules to be terminated with semicolons";
            this.chkTermSemicolons.UseVisualStyleBackColor = true;
            // 
            // chkMinifyExpressions
            // 
            this.chkMinifyExpressions.AutoSize = true;
            this.chkMinifyExpressions.Location = new System.Drawing.Point(5, 173);
            this.chkMinifyExpressions.Name = "chkMinifyExpressions";
            this.chkMinifyExpressions.Size = new System.Drawing.Size(111, 17);
            this.chkMinifyExpressions.TabIndex = 6;
            this.chkMinifyExpressions.Text = "Minify expressions";
            this.chkMinifyExpressions.UseVisualStyleBackColor = true;
            // 
            // chkExpandOutput
            // 
            this.chkExpandOutput.AutoSize = true;
            this.chkExpandOutput.Location = new System.Drawing.Point(5, 79);
            this.chkExpandOutput.Name = "chkExpandOutput";
            this.chkExpandOutput.Size = new System.Drawing.Size(95, 17);
            this.chkExpandOutput.TabIndex = 5;
            this.chkExpandOutput.Text = "Expand output";
            this.chkExpandOutput.UseVisualStyleBackColor = true;
            // 
            // cboCommentMode
            // 
            this.cboCommentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCommentMode.FormattingEnabled = true;
            this.cboCommentMode.Location = new System.Drawing.Point(106, 52);
            this.cboCommentMode.Name = "cboCommentMode";
            this.cboCommentMode.Size = new System.Drawing.Size(121, 21);
            this.cboCommentMode.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comment mode";
            // 
            // cboColorNames
            // 
            this.cboColorNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColorNames.FormattingEnabled = true;
            this.cboColorNames.Location = new System.Drawing.Point(106, 25);
            this.cboColorNames.Name = "cboColorNames";
            this.cboColorNames.Size = new System.Drawing.Size(121, 21);
            this.cboColorNames.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Color names";
            // 
            // chkAllowEmbeddedAspNetBlocks
            // 
            this.chkAllowEmbeddedAspNetBlocks.AutoSize = true;
            this.chkAllowEmbeddedAspNetBlocks.Location = new System.Drawing.Point(5, 3);
            this.chkAllowEmbeddedAspNetBlocks.Name = "chkAllowEmbeddedAspNetBlocks";
            this.chkAllowEmbeddedAspNetBlocks.Size = new System.Drawing.Size(179, 17);
            this.chkAllowEmbeddedAspNetBlocks.TabIndex = 0;
            this.chkAllowEmbeddedAspNetBlocks.Text = "Allow embedded Asp Net blocks";
            this.chkAllowEmbeddedAspNetBlocks.UseVisualStyleBackColor = true;
            // 
            // linkLabelModeInfo
            // 
            this.linkLabelModeInfo.AutoSize = true;
            this.linkLabelModeInfo.Location = new System.Drawing.Point(287, 12);
            this.linkLabelModeInfo.Name = "linkLabelModeInfo";
            this.linkLabelModeInfo.Size = new System.Drawing.Size(85, 13);
            this.linkLabelModeInfo.TabIndex = 32;
            this.linkLabelModeInfo.TabStop = true;
            this.linkLabelModeInfo.Text = "More information";
            this.linkLabelModeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModeInfo_LinkClicked);
            // 
            // MsCss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelModeInfo);
            this.Controls.Add(this.gbSetting);
            this.Name = "MsCss";
            this.Size = new System.Drawing.Size(387, 291);
            this.gbSetting.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineBreakThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndentSpaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAllowEmbeddedAspNetBlocks;
        private System.Windows.Forms.LinkLabel linkLabelModeInfo;
        private System.Windows.Forms.ComboBox cboColorNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCommentMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTermSemicolons;
        private System.Windows.Forms.CheckBox chkMinifyExpressions;
        private System.Windows.Forms.CheckBox chkExpandOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtIndentSpaces;
        private System.Windows.Forms.NumericUpDown txtLineBreakThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOutputMode;
        private System.Windows.Forms.Label label5;
    }
}
