using System.ComponentModel;

namespace Zippy.Chirp.Xml 
{
    public enum MinifyType
    {
        /// <summary>
        /// Not set
        /// </summary>
        Unspecified,

        /// <summary>
        /// YUI engine
        /// </summary>
        [Description("YUI")]
        yui,

        /// <summary>
        /// YUI w/ Michael Ash Regex Enhancement
        /// </summary>
        [Description("YUI w/ Michael Ash Regex Enhancement")]
        yuiMARE,
        
        /// <summary>
        /// YUI Hybrid
        /// </summary>
        [Description("YUI Hybrid")]
        yuiHybrid,
        
        /// <summary>
        /// Google Closure Tools - Advanced
        /// </summary>
        [Description("Google Closure Tools - Advanced")]
        gctAdvanced,

        /// <summary>
        /// Google Closure Tools - Simple
        /// </summary>
        [Description("Google Closure Tools - Simple")]
        gctSimple,

        /// <summary>
        /// Google Closure Tools - Whitespace Only
        /// </summary>
        [Description("Google Closure Tools - Whitespace Only")]
        gctWhiteSpaceOnly,

        /// <summary>
        /// Microsoft Ajax Toolkit
        /// </summary>
        [Description("Microsoft Ajax Toolkit")]
        msAjax,

        /// <summary>
        /// Uglify javascript
        /// </summary>
        [Description("Uglify.js")]
        uglify,

        /// <summary>
        /// js Beautifier
        /// </summary>
        jsBeautifier,
    }
}
