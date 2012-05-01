using Dean.Edwards;

namespace Zippy.Chirp.Engines
{
   public class DeanEdwardsPackerEngine : JsEngine
    {
        public DeanEdwardsPackerEngine()
        {
            Extensions = new[] { this.Settings.ChirpDeanEdwardsPackerFile };
            OutputExtension = this.Settings.OutputExtensionJS;
        }
     
        public override string Transform(string fullFileName, string text, EnvDTE.ProjectItem projectItem)
        {
            ECMAScriptPacker p = new ECMAScriptPacker(this.Settings.ChirpDeanEdwardsPackerEncoding, this.Settings.ChirpDeanEdwardsPackerFastDecode, this.Settings.ChirpDeanEdwardsPackerSpecialChars);
            return p.Pack(text);
        }
    }
}
