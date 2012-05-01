namespace Zippy.Chirp.ConfigurationScreen
{
    partial class CssLint
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
            this.chkCSSLint = new System.Windows.Forms.CheckBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUniqueHeadings = new System.Windows.Forms.CheckBox();
            this.chkAdjoiningClasses = new System.Windows.Forms.CheckBox();
            this.chkEmptyRules = new System.Windows.Forms.CheckBox();
            this.chkDisplayPropertyGrouping = new System.Windows.Forms.CheckBox();
            this.chkFloats = new System.Windows.Forms.CheckBox();
            this.chkFontFaces = new System.Windows.Forms.CheckBox();
            this.chkFontSizes = new System.Windows.Forms.CheckBox();
            this.chkIds = new System.Windows.Forms.CheckBox();
            this.chkQualifiedHeadings = new System.Windows.Forms.CheckBox();
            this.chkZeroUnits = new System.Windows.Forms.CheckBox();
            this.chkVendorPRefix = new System.Windows.Forms.CheckBox();
            this.chkGradients = new System.Windows.Forms.CheckBox();
            this.chkRegexSelectors = new System.Windows.Forms.CheckBox();
            this.chkBoxModel = new System.Windows.Forms.CheckBox();
            this.chkImport = new System.Windows.Forms.CheckBox();
            this.chkImportant = new System.Windows.Forms.CheckBox();
            this.chkCompatibleVendorPrefixes = new System.Windows.Forms.CheckBox();
            this.chkDuplicateProperties = new System.Windows.Forms.CheckBox();
            this.linkLabelModeInfo = new System.Windows.Forms.LinkLabel();
            this.gbSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCSSLint
            // 
            this.chkCSSLint.AutoSize = true;
            this.chkCSSLint.Location = new System.Drawing.Point(3, 12);
            this.chkCSSLint.Name = "chkCSSLint";
            this.chkCSSLint.Size = new System.Drawing.Size(90, 17);
            this.chkCSSLint.TabIndex = 27;
            this.chkCSSLint.Text = "Run CSS Lint";
            this.chkCSSLint.UseVisualStyleBackColor = true;
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.panel1);
            this.gbSetting.Location = new System.Drawing.Point(3, 35);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(381, 252);
            this.gbSetting.TabIndex = 28;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkDuplicateProperties);
            this.panel1.Controls.Add(this.chkCompatibleVendorPrefixes);
            this.panel1.Controls.Add(this.chkImportant);
            this.panel1.Controls.Add(this.chkImport);
            this.panel1.Controls.Add(this.chkBoxModel);
            this.panel1.Controls.Add(this.chkRegexSelectors);
            this.panel1.Controls.Add(this.chkGradients);
            this.panel1.Controls.Add(this.chkVendorPRefix);
            this.panel1.Controls.Add(this.chkZeroUnits);
            this.panel1.Controls.Add(this.chkQualifiedHeadings);
            this.panel1.Controls.Add(this.chkIds);
            this.panel1.Controls.Add(this.chkFontSizes);
            this.panel1.Controls.Add(this.chkFontFaces);
            this.panel1.Controls.Add(this.chkFloats);
            this.panel1.Controls.Add(this.chkDisplayPropertyGrouping);
            this.panel1.Controls.Add(this.chkEmptyRules);
            this.panel1.Controls.Add(this.chkAdjoiningClasses);
            this.panel1.Controls.Add(this.chkUniqueHeadings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 233);
            this.panel1.TabIndex = 29;
            // 
            // chkUniqueHeadings
            // 
            this.chkUniqueHeadings.AutoSize = true;
            this.chkUniqueHeadings.Location = new System.Drawing.Point(5, 188);
            this.chkUniqueHeadings.Name = "chkUniqueHeadings";
            this.chkUniqueHeadings.Size = new System.Drawing.Size(231, 17);
            this.chkUniqueHeadings.TabIndex = 3;
            this.chkUniqueHeadings.Text = "Heading styles should only be defined once";
            this.chkUniqueHeadings.UseVisualStyleBackColor = true;
            // 
            // chkAdjoiningClasses
            // 
            this.chkAdjoiningClasses.AutoSize = true;
            this.chkAdjoiningClasses.Location = new System.Drawing.Point(5, 3);
            this.chkAdjoiningClasses.Name = "chkAdjoiningClasses";
            this.chkAdjoiningClasses.Size = new System.Drawing.Size(154, 17);
            this.chkAdjoiningClasses.TabIndex = 4;
            this.chkAdjoiningClasses.Text = "Don\'t use adjoining classes";
            this.chkAdjoiningClasses.UseVisualStyleBackColor = true;
            // 
            // chkEmptyRules
            // 
            this.chkEmptyRules.AutoSize = true;
            this.chkEmptyRules.Location = new System.Drawing.Point(5, 26);
            this.chkEmptyRules.Name = "chkEmptyRules";
            this.chkEmptyRules.Size = new System.Drawing.Size(122, 17);
            this.chkEmptyRules.TabIndex = 5;
            this.chkEmptyRules.Text = "Remove empty rules";
            this.chkEmptyRules.UseVisualStyleBackColor = true;
            // 
            // chkDisplayPropertyGrouping
            // 
            this.chkDisplayPropertyGrouping.AutoSize = true;
            this.chkDisplayPropertyGrouping.Location = new System.Drawing.Point(5, 49);
            this.chkDisplayPropertyGrouping.Name = "chkDisplayPropertyGrouping";
            this.chkDisplayPropertyGrouping.Size = new System.Drawing.Size(189, 17);
            this.chkDisplayPropertyGrouping.TabIndex = 6;
            this.chkDisplayPropertyGrouping.Text = "Use correct properties for a display";
            this.chkDisplayPropertyGrouping.UseVisualStyleBackColor = true;
            // 
            // chkFloats
            // 
            this.chkFloats.AutoSize = true;
            this.chkFloats.Location = new System.Drawing.Point(5, 72);
            this.chkFloats.Name = "chkFloats";
            this.chkFloats.Size = new System.Drawing.Size(145, 17);
            this.chkFloats.TabIndex = 7;
            this.chkFloats.Text = "Don\'t use too many floats";
            this.chkFloats.UseVisualStyleBackColor = true;
            // 
            // chkFontFaces
            // 
            this.chkFontFaces.AutoSize = true;
            this.chkFontFaces.Location = new System.Drawing.Point(5, 95);
            this.chkFontFaces.Name = "chkFontFaces";
            this.chkFontFaces.Size = new System.Drawing.Size(166, 17);
            this.chkFontFaces.TabIndex = 8;
            this.chkFontFaces.Text = "Don\'t use too many web fonts";
            this.chkFontFaces.UseVisualStyleBackColor = true;
            // 
            // chkFontSizes
            // 
            this.chkFontSizes.AutoSize = true;
            this.chkFontSizes.Location = new System.Drawing.Point(5, 118);
            this.chkFontSizes.Name = "chkFontSizes";
            this.chkFontSizes.Size = new System.Drawing.Size(213, 17);
            this.chkFontSizes.TabIndex = 9;
            this.chkFontSizes.Text = "Don\'t use too may font-size declarations";
            this.chkFontSizes.UseVisualStyleBackColor = true;
            // 
            // chkIds
            // 
            this.chkIds.AutoSize = true;
            this.chkIds.Location = new System.Drawing.Point(5, 141);
            this.chkIds.Name = "chkIds";
            this.chkIds.Size = new System.Drawing.Size(146, 17);
            this.chkIds.TabIndex = 10;
            this.chkIds.Text = "Don\'t use IDs in selectors";
            this.chkIds.UseVisualStyleBackColor = true;
            // 
            // chkQualifiedHeadings
            // 
            this.chkQualifiedHeadings.AutoSize = true;
            this.chkQualifiedHeadings.Location = new System.Drawing.Point(5, 164);
            this.chkQualifiedHeadings.Name = "chkQualifiedHeadings";
            this.chkQualifiedHeadings.Size = new System.Drawing.Size(130, 17);
            this.chkQualifiedHeadings.TabIndex = 11;
            this.chkQualifiedHeadings.Text = "Don\'t qualify headings";
            this.chkQualifiedHeadings.UseVisualStyleBackColor = true;
            // 
            // chkZeroUnits
            // 
            this.chkZeroUnits.AutoSize = true;
            this.chkZeroUnits.Location = new System.Drawing.Point(5, 211);
            this.chkZeroUnits.Name = "chkZeroUnits";
            this.chkZeroUnits.Size = new System.Drawing.Size(160, 17);
            this.chkZeroUnits.TabIndex = 12;
            this.chkZeroUnits.Text = "Zero values don\'t need units";
            this.chkZeroUnits.UseVisualStyleBackColor = true;
            // 
            // chkVendorPRefix
            // 
            this.chkVendorPRefix.AutoSize = true;
            this.chkVendorPRefix.Location = new System.Drawing.Point(5, 234);
            this.chkVendorPRefix.Name = "chkVendorPRefix";
            this.chkVendorPRefix.Size = new System.Drawing.Size(294, 17);
            this.chkVendorPRefix.TabIndex = 13;
            this.chkVendorPRefix.Text = "Vendor prefixed properties should also have the standard";
            this.chkVendorPRefix.UseVisualStyleBackColor = true;
            // 
            // chkGradients
            // 
            this.chkGradients.AutoSize = true;
            this.chkGradients.Location = new System.Drawing.Point(5, 257);
            this.chkGradients.Name = "chkGradients";
            this.chkGradients.Size = new System.Drawing.Size(220, 17);
            this.chkGradients.TabIndex = 14;
            this.chkGradients.Text = "CSS gradients require all browser prefixes";
            this.chkGradients.UseVisualStyleBackColor = true;
            // 
            // chkRegexSelectors
            // 
            this.chkRegexSelectors.AutoSize = true;
            this.chkRegexSelectors.Location = new System.Drawing.Point(5, 280);
            this.chkRegexSelectors.Name = "chkRegexSelectors";
            this.chkRegexSelectors.Size = new System.Drawing.Size(254, 17);
            this.chkRegexSelectors.TabIndex = 15;
            this.chkRegexSelectors.Text = "Avoid selectors that look like regular expressions";
            this.chkRegexSelectors.UseVisualStyleBackColor = true;
            // 
            // chkBoxModel
            // 
            this.chkBoxModel.AutoSize = true;
            this.chkBoxModel.Location = new System.Drawing.Point(5, 303);
            this.chkBoxModel.Name = "chkBoxModel";
            this.chkBoxModel.Size = new System.Drawing.Size(166, 17);
            this.chkBoxModel.TabIndex = 16;
            this.chkBoxModel.Text = "Beware of broken box models";
            this.chkBoxModel.UseVisualStyleBackColor = true;
            // 
            // chkImport
            // 
            this.chkImport.AutoSize = true;
            this.chkImport.Location = new System.Drawing.Point(5, 326);
            this.chkImport.Name = "chkImport";
            this.chkImport.Size = new System.Drawing.Size(113, 17);
            this.chkImport.TabIndex = 17;
            this.chkImport.Text = "Don\'t use @import";
            this.chkImport.UseVisualStyleBackColor = true;
            // 
            // chkImportant
            // 
            this.chkImportant.AutoSize = true;
            this.chkImportant.Location = new System.Drawing.Point(5, 349);
            this.chkImportant.Name = "chkImportant";
            this.chkImportant.Size = new System.Drawing.Size(120, 17);
            this.chkImportant.TabIndex = 18;
            this.chkImportant.Text = "Don\'t use !important";
            this.chkImportant.UseVisualStyleBackColor = true;
            // 
            // chkCompatibleVendorPrefixes
            // 
            this.chkCompatibleVendorPrefixes.AutoSize = true;
            this.chkCompatibleVendorPrefixes.Location = new System.Drawing.Point(5, 372);
            this.chkCompatibleVendorPrefixes.Name = "chkCompatibleVendorPrefixes";
            this.chkCompatibleVendorPrefixes.Size = new System.Drawing.Size(203, 17);
            this.chkCompatibleVendorPrefixes.TabIndex = 19;
            this.chkCompatibleVendorPrefixes.Text = "Include all compatible vendor prefixes";
            this.chkCompatibleVendorPrefixes.UseVisualStyleBackColor = true;
            // 
            // chkDuplicateProperties
            // 
            this.chkDuplicateProperties.AutoSize = true;
            this.chkDuplicateProperties.Location = new System.Drawing.Point(5, 395);
            this.chkDuplicateProperties.Name = "chkDuplicateProperties";
            this.chkDuplicateProperties.Size = new System.Drawing.Size(148, 17);
            this.chkDuplicateProperties.TabIndex = 20;
            this.chkDuplicateProperties.Text = "Avoid duplicate properties";
            this.chkDuplicateProperties.UseVisualStyleBackColor = true;
            // 
            // linkLabelModeInfo
            // 
            this.linkLabelModeInfo.AutoSize = true;
            this.linkLabelModeInfo.Location = new System.Drawing.Point(287, 12);
            this.linkLabelModeInfo.Name = "linkLabelModeInfo";
            this.linkLabelModeInfo.Size = new System.Drawing.Size(85, 13);
            this.linkLabelModeInfo.TabIndex = 29;
            this.linkLabelModeInfo.TabStop = true;
            this.linkLabelModeInfo.Text = "More information";
            this.linkLabelModeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelModeInfo_LinkClicked);
            // 
            // CssLint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelModeInfo);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.chkCSSLint);
            this.Name = "CssLint";
            this.Size = new System.Drawing.Size(387, 291);
            this.gbSetting.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCSSLint;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkUniqueHeadings;
        private System.Windows.Forms.CheckBox chkQualifiedHeadings;
        private System.Windows.Forms.CheckBox chkIds;
        private System.Windows.Forms.CheckBox chkFontSizes;
        private System.Windows.Forms.CheckBox chkFontFaces;
        private System.Windows.Forms.CheckBox chkFloats;
        private System.Windows.Forms.CheckBox chkDisplayPropertyGrouping;
        private System.Windows.Forms.CheckBox chkEmptyRules;
        private System.Windows.Forms.CheckBox chkAdjoiningClasses;
        private System.Windows.Forms.CheckBox chkDuplicateProperties;
        private System.Windows.Forms.CheckBox chkCompatibleVendorPrefixes;
        private System.Windows.Forms.CheckBox chkImportant;
        private System.Windows.Forms.CheckBox chkImport;
        private System.Windows.Forms.CheckBox chkBoxModel;
        private System.Windows.Forms.CheckBox chkRegexSelectors;
        private System.Windows.Forms.CheckBox chkGradients;
        private System.Windows.Forms.CheckBox chkVendorPRefix;
        private System.Windows.Forms.CheckBox chkZeroUnits;
        private System.Windows.Forms.LinkLabel linkLabelModeInfo;
    }
}
