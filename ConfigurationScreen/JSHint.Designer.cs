namespace Zippy.Chirp.ConfigurationScreen
{
    partial class JSHint
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
            this.chkJSHint = new System.Windows.Forms.CheckBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMaxerr = new System.Windows.Forms.NumericUpDown();
            this.chkWhite = new System.Windows.Forms.CheckBox();
            this.chkUndef = new System.Windows.Forms.CheckBox();
            this.chkSub = new System.Windows.Forms.CheckBox();
            this.chkStrict = new System.Windows.Forms.CheckBox();
            this.chkRegex = new System.Windows.Forms.CheckBox();
            this.chkPlusPlus = new System.Windows.Forms.CheckBox();
            this.chkPassfail = new System.Windows.Forms.CheckBox();
            this.chkNoVar = new System.Windows.Forms.CheckBox();
            this.chkNoNew = new System.Windows.Forms.CheckBox();
            this.chkNomen = new System.Windows.Forms.CheckBox();
            this.chkNoEmpty = new System.Windows.Forms.CheckBox();
            this.chkNoArg = new System.Windows.Forms.CheckBox();
            this.chkNewcap = new System.Windows.Forms.CheckBox();
            this.chkAsi = new System.Windows.Forms.CheckBox();
            this.chkLaxbreak = new System.Windows.Forms.CheckBox();
            this.chkBitwise = new System.Windows.Forms.CheckBox();
            this.chkImmed = new System.Windows.Forms.CheckBox();
            this.chkBoss = new System.Windows.Forms.CheckBox();
            this.chkForin = new System.Windows.Forms.CheckBox();
            this.chkCurly = new System.Windows.Forms.CheckBox();
            this.chkEvil = new System.Windows.Forms.CheckBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.chkEqnull = new System.Windows.Forms.CheckBox();
            this.chkEqeqeq = new System.Windows.Forms.CheckBox();
            this.linkLabelModeInfo = new System.Windows.Forms.LinkLabel();
            this.gbSetting.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMaxerr)).BeginInit();
            this.SuspendLayout();
            // 
            // chkJSHint
            // 
            this.chkJSHint.AutoSize = true;
            this.chkJSHint.Location = new System.Drawing.Point(3, 12);
            this.chkJSHint.Name = "chkJSHint";
            this.chkJSHint.Size = new System.Drawing.Size(83, 17);
            this.chkJSHint.TabIndex = 26;
            this.chkJSHint.Text = "Run JS Hint";
            this.chkJSHint.UseVisualStyleBackColor = true;
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
            this.gbSetting.TabIndex = 27;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Options";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TxtMaxerr);
            this.panel2.Controls.Add(this.chkWhite);
            this.panel2.Controls.Add(this.chkUndef);
            this.panel2.Controls.Add(this.chkSub);
            this.panel2.Controls.Add(this.chkStrict);
            this.panel2.Controls.Add(this.chkRegex);
            this.panel2.Controls.Add(this.chkPlusPlus);
            this.panel2.Controls.Add(this.chkPassfail);
            this.panel2.Controls.Add(this.chkNoVar);
            this.panel2.Controls.Add(this.chkNoNew);
            this.panel2.Controls.Add(this.chkNomen);
            this.panel2.Controls.Add(this.chkNoEmpty);
            this.panel2.Controls.Add(this.chkNoArg);
            this.panel2.Controls.Add(this.chkNewcap);
            this.panel2.Controls.Add(this.chkAsi);
            this.panel2.Controls.Add(this.chkLaxbreak);
            this.panel2.Controls.Add(this.chkBitwise);
            this.panel2.Controls.Add(this.chkImmed);
            this.panel2.Controls.Add(this.chkBoss);
            this.panel2.Controls.Add(this.chkForin);
            this.panel2.Controls.Add(this.chkCurly);
            this.panel2.Controls.Add(this.chkEvil);
            this.panel2.Controls.Add(this.chkDebug);
            this.panel2.Controls.Add(this.chkEqnull);
            this.panel2.Controls.Add(this.chkEqeqeq);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 233);
            this.panel2.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Maximum number of errors before stops processing your source";
            // 
            // TxtMaxerr
            // 
            this.TxtMaxerr.Location = new System.Drawing.Point(3, 532);
            this.TxtMaxerr.Name = "TxtMaxerr";
            this.TxtMaxerr.Size = new System.Drawing.Size(42, 20);
            this.TxtMaxerr.TabIndex = 25;
            this.TxtMaxerr.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chkWhite
            // 
            this.chkWhite.AutoSize = true;
            this.chkWhite.Location = new System.Drawing.Point(3, 509);
            this.chkWhite.Name = "chkWhite";
            this.chkWhite.Size = new System.Drawing.Size(251, 17);
            this.chkWhite.TabIndex = 24;
            this.chkWhite.Text = "Check your code against strict whitespace rules";
            this.chkWhite.UseVisualStyleBackColor = true;
            // 
            // chkUndef
            // 
            this.chkUndef.AutoSize = true;
            this.chkUndef.Location = new System.Drawing.Point(3, 487);
            this.chkUndef.Name = "chkUndef";
            this.chkUndef.Size = new System.Drawing.Size(332, 17);
            this.chkUndef.TabIndex = 23;
            this.chkUndef.Text = "Require all non-global variables be declared before they are used";
            this.chkUndef.UseVisualStyleBackColor = true;
            // 
            // chkSub
            // 
            this.chkSub.AutoSize = true;
            this.chkSub.Location = new System.Drawing.Point(3, 465);
            this.chkSub.Name = "chkSub";
            this.chkSub.Size = new System.Drawing.Size(207, 17);
            this.chkSub.TabIndex = 22;
            this.chkSub.Text = "Tolerate all forms of subscript notation.";
            this.chkSub.UseVisualStyleBackColor = true;
            // 
            // chkStrict
            // 
            this.chkStrict.AutoSize = true;
            this.chkStrict.Location = new System.Drawing.Point(3, 443);
            this.chkStrict.Name = "chkStrict";
            this.chkStrict.Size = new System.Drawing.Size(211, 17);
            this.chkStrict.TabIndex = 21;
            this.chkStrict.Text = "Require you to use \"use strict\"; pragma";
            this.chkStrict.UseVisualStyleBackColor = true;
            // 
            // chkRegex
            // 
            this.chkRegex.AutoSize = true;
            this.chkRegex.Location = new System.Drawing.Point(3, 421);
            this.chkRegex.Name = "chkRegex";
            this.chkRegex.Size = new System.Drawing.Size(220, 17);
            this.chkRegex.TabIndex = 20;
            this.chkRegex.Text = "Disallow . and [^...] in regular expressions";
            this.chkRegex.UseVisualStyleBackColor = true;
            // 
            // chkPlusPlus
            // 
            this.chkPlusPlus.AutoSize = true;
            this.chkPlusPlus.Location = new System.Drawing.Point(3, 399);
            this.chkPlusPlus.Name = "chkPlusPlus";
            this.chkPlusPlus.Size = new System.Drawing.Size(281, 17);
            this.chkPlusPlus.TabIndex = 19;
            this.chkPlusPlus.Text = "Prohibit the use of increment and decrement operators";
            this.chkPlusPlus.UseVisualStyleBackColor = true;
            // 
            // chkPassfail
            // 
            this.chkPassfail.AutoSize = true;
            this.chkPassfail.Location = new System.Drawing.Point(3, 377);
            this.chkPassfail.Name = "chkPassfail";
            this.chkPassfail.Size = new System.Drawing.Size(183, 17);
            this.chkPassfail.TabIndex = 18;
            this.chkPassfail.Text = "Stop on the first error it encounter";
            this.chkPassfail.UseVisualStyleBackColor = true;
            // 
            // chkNoVar
            // 
            this.chkNoVar.AutoSize = true;
            this.chkNoVar.Location = new System.Drawing.Point(3, 355);
            this.chkNoVar.Name = "chkNoVar";
            this.chkNoVar.Size = new System.Drawing.Size(220, 17);
            this.chkNoVar.TabIndex = 17;
            this.chkNoVar.Text = "Allow only one var statement per function";
            this.chkNoVar.UseVisualStyleBackColor = true;
            // 
            // chkNoNew
            // 
            this.chkNoNew.AutoSize = true;
            this.chkNoNew.Location = new System.Drawing.Point(3, 333);
            this.chkNoNew.Name = "chkNoNew";
            this.chkNoNew.Size = new System.Drawing.Size(244, 17);
            this.chkNoNew.TabIndex = 16;
            this.chkNoNew.Text = "Prohibit the use of constructors for side-effects";
            this.chkNoNew.UseVisualStyleBackColor = true;
            // 
            // chkNomen
            // 
            this.chkNomen.AutoSize = true;
            this.chkNomen.Location = new System.Drawing.Point(3, 311);
            this.chkNomen.Name = "chkNomen";
            this.chkNomen.Size = new System.Drawing.Size(281, 17);
            this.chkNomen.TabIndex = 15;
            this.chkNomen.Text = "Disallow the use of initial or trailing underbars in names";
            this.chkNomen.UseVisualStyleBackColor = true;
            // 
            // chkNoEmpty
            // 
            this.chkNoEmpty.AutoSize = true;
            this.chkNoEmpty.Location = new System.Drawing.Point(3, 289);
            this.chkNoEmpty.Name = "chkNoEmpty";
            this.chkNoEmpty.Size = new System.Drawing.Size(176, 17);
            this.chkNoEmpty.TabIndex = 14;
            this.chkNoEmpty.Text = "Prohibit the use of empty blocks";
            this.chkNoEmpty.UseVisualStyleBackColor = true;
            // 
            // chkNoArg
            // 
            this.chkNoArg.AutoSize = true;
            this.chkNoArg.Location = new System.Drawing.Point(3, 267);
            this.chkNoArg.Name = "chkNoArg";
            this.chkNoArg.Size = new System.Drawing.Size(295, 17);
            this.chkNoArg.TabIndex = 13;
            this.chkNoArg.Text = "Prohibit the use of arguments.caller and arguments.callee";
            this.chkNoArg.UseVisualStyleBackColor = true;
            // 
            // chkNewcap
            // 
            this.chkNewcap.AutoSize = true;
            this.chkNewcap.Location = new System.Drawing.Point(3, 245);
            this.chkNewcap.Name = "chkNewcap";
            this.chkNewcap.Size = new System.Drawing.Size(266, 17);
            this.chkNewcap.TabIndex = 12;
            this.chkNewcap.Text = "Require that you capitalize all constructor functions";
            this.chkNewcap.UseVisualStyleBackColor = true;
            // 
            // chkAsi
            // 
            this.chkAsi.Location = new System.Drawing.Point(3, 3);
            this.chkAsi.Name = "chkAsi";
            this.chkAsi.Size = new System.Drawing.Size(256, 17);
            this.chkAsi.TabIndex = 0;
            this.chkAsi.Text = "Tolerate the use of automatic semicolon insertion";
            this.chkAsi.UseVisualStyleBackColor = true;
            // 
            // chkLaxbreak
            // 
            this.chkLaxbreak.AutoSize = true;
            this.chkLaxbreak.Location = new System.Drawing.Point(3, 223);
            this.chkLaxbreak.Name = "chkLaxbreak";
            this.chkLaxbreak.Size = new System.Drawing.Size(130, 17);
            this.chkLaxbreak.TabIndex = 11;
            this.chkLaxbreak.Text = "Not check line breaks";
            this.chkLaxbreak.UseVisualStyleBackColor = true;
            // 
            // chkBitwise
            // 
            this.chkBitwise.AutoSize = true;
            this.chkBitwise.Location = new System.Drawing.Point(3, 25);
            this.chkBitwise.Name = "chkBitwise";
            this.chkBitwise.Size = new System.Drawing.Size(196, 17);
            this.chkBitwise.TabIndex = 1;
            this.chkBitwise.Text = "Prohibit the use of bitwise operators.";
            this.chkBitwise.UseVisualStyleBackColor = true;
            // 
            // chkImmed
            // 
            this.chkImmed.AutoSize = true;
            this.chkImmed.Location = new System.Drawing.Point(3, 201);
            this.chkImmed.Name = "chkImmed";
            this.chkImmed.Size = new System.Drawing.Size(287, 17);
            this.chkImmed.TabIndex = 10;
            this.chkImmed.Text = "Require immediate invocations to be wrapped in parens";
            this.chkImmed.UseVisualStyleBackColor = true;
            // 
            // chkBoss
            // 
            this.chkBoss.AutoSize = true;
            this.chkBoss.Location = new System.Drawing.Point(3, 47);
            this.chkBoss.Name = "chkBoss";
            this.chkBoss.Size = new System.Drawing.Size(213, 17);
            this.chkBoss.TabIndex = 2;
            this.chkBoss.Text = "Allow assignments inside if/for/while/do";
            this.chkBoss.UseVisualStyleBackColor = true;
            // 
            // chkForin
            // 
            this.chkForin.AutoSize = true;
            this.chkForin.Location = new System.Drawing.Point(3, 179);
            this.chkForin.Name = "chkForin";
            this.chkForin.Size = new System.Drawing.Size(259, 17);
            this.chkForin.TabIndex = 9;
            this.chkForin.Text = "Disallow the use of for in without hasOwnProperty";
            this.chkForin.UseVisualStyleBackColor = true;
            // 
            // chkCurly
            // 
            this.chkCurly.AutoSize = true;
            this.chkCurly.Location = new System.Drawing.Point(3, 69);
            this.chkCurly.Name = "chkCurly";
            this.chkCurly.Size = new System.Drawing.Size(206, 17);
            this.chkCurly.TabIndex = 4;
            this.chkCurly.Text = "Require curly braces around all blocks";
            this.chkCurly.UseVisualStyleBackColor = true;
            // 
            // chkEvil
            // 
            this.chkEvil.AutoSize = true;
            this.chkEvil.Location = new System.Drawing.Point(3, 157);
            this.chkEvil.Name = "chkEvil";
            this.chkEvil.Size = new System.Drawing.Size(124, 17);
            this.chkEvil.TabIndex = 8;
            this.chkEvil.Text = "Allow the use of eval";
            this.chkEvil.UseVisualStyleBackColor = true;
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(3, 91);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(153, 17);
            this.chkDebug.TabIndex = 5;
            this.chkDebug.Text = "Allow debugger statements";
            this.chkDebug.UseVisualStyleBackColor = true;
            // 
            // chkEqnull
            // 
            this.chkEqnull.AutoSize = true;
            this.chkEqnull.Location = new System.Drawing.Point(3, 135);
            this.chkEqnull.Name = "chkEqnull";
            this.chkEqnull.Size = new System.Drawing.Size(135, 17);
            this.chkEqnull.TabIndex = 7;
            this.chkEqnull.Text = "Allow the use of == null";
            this.chkEqnull.UseVisualStyleBackColor = true;
            // 
            // chkEqeqeq
            // 
            this.chkEqeqeq.AutoSize = true;
            this.chkEqeqeq.Location = new System.Drawing.Point(3, 113);
            this.chkEqeqeq.Name = "chkEqeqeq";
            this.chkEqeqeq.Size = new System.Drawing.Size(274, 17);
            this.chkEqeqeq.TabIndex = 6;
            this.chkEqeqeq.Text = "Require that you use === and !== for all comparisons";
            this.chkEqeqeq.UseVisualStyleBackColor = true;
            // 
            // linkLabelModeInfo
            // 
            this.linkLabelModeInfo.AutoSize = true;
            this.linkLabelModeInfo.Location = new System.Drawing.Point(287, 12);
            this.linkLabelModeInfo.Name = "linkLabelModeInfo";
            this.linkLabelModeInfo.Size = new System.Drawing.Size(85, 13);
            this.linkLabelModeInfo.TabIndex = 30;
            this.linkLabelModeInfo.TabStop = true;
            this.linkLabelModeInfo.Text = "More information";
            this.linkLabelModeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModeInfo_LinkClicked);
            // 
            // JSHint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.linkLabelModeInfo);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.chkJSHint);
            this.Name = "JSHint";
            this.Size = new System.Drawing.Size(387, 291);
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtMaxerr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkJSHint;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TxtMaxerr;
        private System.Windows.Forms.CheckBox chkWhite;
        private System.Windows.Forms.CheckBox chkUndef;
        private System.Windows.Forms.CheckBox chkSub;
        private System.Windows.Forms.CheckBox chkStrict;
        private System.Windows.Forms.CheckBox chkRegex;
        private System.Windows.Forms.CheckBox chkPlusPlus;
        private System.Windows.Forms.CheckBox chkPassfail;
        private System.Windows.Forms.CheckBox chkNoVar;
        private System.Windows.Forms.CheckBox chkNoNew;
        private System.Windows.Forms.CheckBox chkNomen;
        private System.Windows.Forms.CheckBox chkNoEmpty;
        private System.Windows.Forms.CheckBox chkNoArg;
        private System.Windows.Forms.CheckBox chkNewcap;
        private System.Windows.Forms.CheckBox chkAsi;
        private System.Windows.Forms.CheckBox chkLaxbreak;
        private System.Windows.Forms.CheckBox chkBitwise;
        private System.Windows.Forms.CheckBox chkImmed;
        private System.Windows.Forms.CheckBox chkBoss;
        private System.Windows.Forms.CheckBox chkForin;
        private System.Windows.Forms.CheckBox chkCurly;
        private System.Windows.Forms.CheckBox chkEvil;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.CheckBox chkEqnull;
        private System.Windows.Forms.CheckBox chkEqeqeq;
        private System.Windows.Forms.LinkLabel linkLabelModeInfo;
    }
}
