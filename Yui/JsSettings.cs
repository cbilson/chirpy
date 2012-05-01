
namespace Zippy.Chirp.Yui
{
    public class JsSettings
    {
        #region Constructors
        public JsSettings()
        {
            this.IsObfuscateJavascript = true;
            this.PreserveAllSemiColons = false;
            this.DisableOptimizations = false;
            this.LineBreakPosition = 0;
        }
        #endregion

        public bool IsObfuscateJavascript { get; set; }

        public bool PreserveAllSemiColons { get; set; }

        public bool DisableOptimizations { get; set; }

        public int LineBreakPosition { get; set; }
    }
}
