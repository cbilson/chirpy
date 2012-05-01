using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;
using Zippy.Chirp.JavaScript;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class UglifyJsEngineTest :BaseTest
    {

        private void YuiJsDefaultSetting()
        {
            Settings setting = Settings.Instance();
            setting.YuiJsSettings.DisableOptimizations = false;
            setting.YuiJsSettings.IsObfuscateJavascript = false;
            setting.YuiJsSettings.LineBreakPosition = 0;
            setting.YuiJsSettings.PreserveAllSemiColons = false;
            setting.Save();
        }

        [TestMethod]
        public void TestUglifyJsEngine()
        {
            this.YuiJsDefaultSetting();
            string code = "if(test) {\r\n\t alert('test'); }";
            code = TestEngine<Zippy.Chirp.Engines.UglifyEngine>("c:\\test.js", code);

            Assert.IsTrue(code.Equals("test&&alert(\"test\")") || code.Equals("test&&alert(\"test\");"));
        }

        [TestMethod]
        public void CanMinifyJQuery()
        {
            string minid, code = Zippy.Chirp.JavaScript.Extensibility.Instance.GetContents(new Uri("http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"));
            minid = Uglify.squeeze_it(code);

            minid.Length.Should().Be.InRange(0, code.Length - 1);
        }

        [TestMethod]
        public void MinifyBadCode()
        {
            string minid, code = "----*&;lij;{lo23i41";
            try
            {
                minid = Uglify.squeeze_it(code);

            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine(ex);
            }

        }
    }
}
