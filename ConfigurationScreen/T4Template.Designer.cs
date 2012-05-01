namespace Zippy.Chirp.ConfigurationScreen
{
    partial class T4Template
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSmartRunT4MVC = new System.Windows.Forms.CheckBox();
            this.txtT4RunAsBuildTemplate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkT4RunOnBuild = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSmartRunT4MVC);
            this.groupBox1.Controls.Add(this.txtT4RunAsBuildTemplate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkT4RunOnBuild);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 106);
            this.groupBox1.TabIndex = 15;
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
            // 
            // T4Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "T4Template";
            this.Size = new System.Drawing.Size(335, 142);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSmartRunT4MVC;
        private System.Windows.Forms.TextBox txtT4RunAsBuildTemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkT4RunOnBuild;
    }
}
