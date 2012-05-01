namespace Zippy.Chirp
{
    partial class ConfigurationScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtChirpJsFile = new System.Windows.Forms.TextBox();
            this.txtChirpSimpleJsFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChirpWhiteSpaceJsFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChirpYUIJsFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChirpLessFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChirpCssFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSmartRunT4MVC = new System.Windows.Forms.CheckBox();
            this.txtT4RunAsBuildTemplate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkT4RunOnBuild = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHybridCssFile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMichaelAshCssFile = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Closure Compiler - Advanced :";
            // 
            // txtChirpJsFile
            // 
            this.txtChirpJsFile.Location = new System.Drawing.Point(187, 22);
            this.txtChirpJsFile.Name = "txtChirpJsFile";
            this.txtChirpJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpJsFile.TabIndex = 1;
            this.txtChirpJsFile.Tag = "ChipJsGctFile";
            this.txtChirpJsFile.Text = ".gct.js";
            // 
            // txtChirpSimpleJsFile
            // 
            this.txtChirpSimpleJsFile.Location = new System.Drawing.Point(187, 48);
            this.txtChirpSimpleJsFile.Name = "txtChirpSimpleJsFile";
            this.txtChirpSimpleJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpSimpleJsFile.TabIndex = 3;
            this.txtChirpSimpleJsFile.Text = ".simple.js";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Closure Compiler - Simple :";
            // 
            // txtChirpWhiteSpaceJsFile
            // 
            this.txtChirpWhiteSpaceJsFile.Location = new System.Drawing.Point(187, 74);
            this.txtChirpWhiteSpaceJsFile.Name = "txtChirpWhiteSpaceJsFile";
            this.txtChirpWhiteSpaceJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpWhiteSpaceJsFile.TabIndex = 5;
            this.txtChirpWhiteSpaceJsFile.Text = ".whitespace.js";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Closure Compiler - Whitespace only :";
            // 
            // txtChirpYUIJsFile
            // 
            this.txtChirpYUIJsFile.Location = new System.Drawing.Point(187, 100);
            this.txtChirpYUIJsFile.Name = "txtChirpYUIJsFile";
            this.txtChirpYUIJsFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpYUIJsFile.TabIndex = 7;
            this.txtChirpYUIJsFile.Text = ".yui.js";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "YUI Compressor :";
            // 
            // txtChirpLessFile
            // 
            this.txtChirpLessFile.Location = new System.Drawing.Point(184, 25);
            this.txtChirpLessFile.Name = "txtChirpLessFile";
            this.txtChirpLessFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpLessFile.TabIndex = 9;
            this.txtChirpLessFile.Text = ".chirp.less";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "LESS :";
            // 
            // txtChirpCssFile
            // 
            this.txtChirpCssFile.Location = new System.Drawing.Point(184, 51);
            this.txtChirpCssFile.Name = "txtChirpCssFile";
            this.txtChirpCssFile.Size = new System.Drawing.Size(128, 20);
            this.txtChirpCssFile.TabIndex = 11;
            this.txtChirpCssFile.Text = ".chirp.css";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "YUI Compressor :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSmartRunT4MVC);
            this.groupBox1.Controls.Add(this.txtT4RunAsBuildTemplate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkT4RunOnBuild);
            this.groupBox1.Location = new System.Drawing.Point(11, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 106);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "T4 template";
            // 
            // chkSmartRunT4MVC
            // 
            this.chkSmartRunT4MVC.AutoSize = true;
            this.chkSmartRunT4MVC.Location = new System.Drawing.Point(105, 28);
            this.chkSmartRunT4MVC.Name = "chkSmartRunT4MVC";
            this.chkSmartRunT4MVC.Size = new System.Drawing.Size(110, 17);
            this.chkSmartRunT4MVC.TabIndex = 3;
            this.chkSmartRunT4MVC.Text = "Smart run T4MVC";
            this.chkSmartRunT4MVC.UseVisualStyleBackColor = true;
            // 
            // txtT4RunAsBuildTemplate
            // 
            this.txtT4RunAsBuildTemplate.Location = new System.Drawing.Point(74, 57);
            this.txtT4RunAsBuildTemplate.Multiline = true;
            this.txtT4RunAsBuildTemplate.Name = "txtT4RunAsBuildTemplate";
            this.txtT4RunAsBuildTemplate.Size = new System.Drawing.Size(238, 41);
            this.txtT4RunAsBuildTemplate.TabIndex = 2;
            this.txtT4RunAsBuildTemplate.Text = "T4MVC.tt,NHibernateMapping.tt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Template :";
            // 
            // chkT4RunOnBuild
            // 
            this.chkT4RunOnBuild.AutoSize = true;
            this.chkT4RunOnBuild.Location = new System.Drawing.Point(12, 28);
            this.chkT4RunOnBuild.Name = "chkT4RunOnBuild";
            this.chkT4RunOnBuild.Size = new System.Drawing.Size(87, 17);
            this.chkT4RunOnBuild.TabIndex = 0;
            this.chkT4RunOnBuild.Text = "Run on Build";
            this.chkT4RunOnBuild.UseVisualStyleBackColor = true;
            this.chkT4RunOnBuild.CheckedChanged += new System.EventHandler(this.chkT4RunOnBuild_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtChirpJsFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtChirpSimpleJsFile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtChirpWhiteSpaceJsFile);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtChirpYUIJsFile);
            this.groupBox2.Location = new System.Drawing.Point(11, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 126);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Javascript";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtHybridCssFile);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtMichaelAshCssFile);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtChirpLessFile);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtChirpCssFile);
            this.groupBox3.Location = new System.Drawing.Point(11, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 140);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CSS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Hybrid :";
            // 
            // txtHybridCssFile
            // 
            this.txtHybridCssFile.Location = new System.Drawing.Point(184, 103);
            this.txtHybridCssFile.Name = "txtHybridCssFile";
            this.txtHybridCssFile.Size = new System.Drawing.Size(128, 20);
            this.txtHybridCssFile.TabIndex = 15;
            this.txtHybridCssFile.Text = ".chirp.css";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "MichaelAshRegexEnhancements :";
            // 
            // txtMichaelAshCssFile
            // 
            this.txtMichaelAshCssFile.Location = new System.Drawing.Point(184, 77);
            this.txtMichaelAshCssFile.Name = "txtMichaelAshCssFile";
            this.txtMichaelAshCssFile.Size = new System.Drawing.Size(128, 20);
            this.txtMichaelAshCssFile.TabIndex = 13;
            this.txtMichaelAshCssFile.Text = ".chirp.css";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 507);
            this.panel1.TabIndex = 17;
            // 
            // ConfigurationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "ConfigurationScreen";
            this.Size = new System.Drawing.Size(574, 507);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChirpJsFile;
        private System.Windows.Forms.TextBox txtChirpSimpleJsFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChirpWhiteSpaceJsFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChirpYUIJsFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChirpLessFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChirpCssFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkT4RunOnBuild;
        private System.Windows.Forms.TextBox txtT4RunAsBuildTemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkSmartRunT4MVC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHybridCssFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMichaelAshCssFile;
        private System.Windows.Forms.Panel panel1;

    }
}
