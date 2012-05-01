namespace Zippy.Chirp.ConfigurationScreen
{
    partial class GoogleClosure
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
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBoxOffline = new System.Windows.Forms.GroupBox();
            this.btnFindJava = new System.Windows.Forms.Button();
            this.textBoxJavaPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableOfline = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabelModeInfo = new System.Windows.Forms.LinkLabel();
            this.groupBox3.SuspendLayout();
            this.groupBoxOffline.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBoxOffline);
            this.groupBox3.Controls.Add(this.chkEnableOfline);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(3, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 161);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Google Closure";
            // 
            // groupBoxOffline
            // 
            this.groupBoxOffline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOffline.Controls.Add(this.btnFindJava);
            this.groupBoxOffline.Controls.Add(this.textBoxJavaPath);
            this.groupBoxOffline.Controls.Add(this.label1);
            this.groupBoxOffline.Enabled = false;
            this.groupBoxOffline.Location = new System.Drawing.Point(9, 49);
            this.groupBoxOffline.Name = "groupBoxOffline";
            this.groupBoxOffline.Size = new System.Drawing.Size(363, 90);
            this.groupBoxOffline.TabIndex = 13;
            this.groupBoxOffline.TabStop = false;
            this.groupBoxOffline.Text = "Offline Settings";
            // 
            // btnFindJava
            // 
            this.btnFindJava.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindJava.Location = new System.Drawing.Point(282, 11);
            this.btnFindJava.Name = "btnFindJava";
            this.btnFindJava.Size = new System.Drawing.Size(75, 23);
            this.btnFindJava.TabIndex = 13;
            this.btnFindJava.Text = "Find Java";
            this.btnFindJava.UseVisualStyleBackColor = true;
            this.btnFindJava.Click += new System.EventHandler(this.FindJava_Click);
            // 
            // textBoxJavaPath
            // 
            this.textBoxJavaPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxJavaPath.Enabled = false;
            this.textBoxJavaPath.Location = new System.Drawing.Point(108, 13);
            this.textBoxJavaPath.Name = "textBoxJavaPath";
            this.textBoxJavaPath.Size = new System.Drawing.Size(158, 20);
            this.textBoxJavaPath.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Path to Java :";
            // 
            // chkEnableOfline
            // 
            this.chkEnableOfline.AutoSize = true;
            this.chkEnableOfline.Location = new System.Drawing.Point(299, 16);
            this.chkEnableOfline.Name = "chkEnableOfline";
            this.chkEnableOfline.Size = new System.Drawing.Size(15, 14);
            this.chkEnableOfline.TabIndex = 12;
            this.chkEnableOfline.UseVisualStyleBackColor = true;
            this.chkEnableOfline.CheckedChanged += new System.EventHandler(this.EnableOfline_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Use Offline Compression :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // linkLabelModeInfo
            // 
            this.linkLabelModeInfo.AutoSize = true;
            this.linkLabelModeInfo.Location = new System.Drawing.Point(287, 12);
            this.linkLabelModeInfo.Name = "linkLabelModeInfo";
            this.linkLabelModeInfo.Size = new System.Drawing.Size(85, 13);
            this.linkLabelModeInfo.TabIndex = 35;
            this.linkLabelModeInfo.TabStop = true;
            this.linkLabelModeInfo.Text = "More information";
            this.linkLabelModeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModeInfo_LinkClicked);
            // 
            // GoogleClosure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelModeInfo);
            this.Controls.Add(this.groupBox3);
            this.Name = "GoogleClosure";
            this.Size = new System.Drawing.Size(387, 203);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxOffline.ResumeLayout(false);
            this.groupBoxOffline.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxOffline;
        private System.Windows.Forms.CheckBox chkEnableOfline;
        private System.Windows.Forms.Button btnFindJava;
        private System.Windows.Forms.TextBox textBoxJavaPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabelModeInfo;
    }
}
