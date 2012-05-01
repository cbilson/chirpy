using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class YuiJsEngineTest:BaseTest
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
        public void TestYuiJsEngine()
        {
            this.YuiJsDefaultSetting();
            string code = "if(test) {\r\n\t alert('test'); }";
            code = TestEngine<Zippy.Chirp.Engines.YuiJsEngine>("c:\\test.js", code);

            Assert.IsTrue(code == "if(test){alert(\"test\")};" || code == "if(test){alert(\"test\")\n};");
        }

        [TestMethod]
        public void TestYuiJsEngineSingleineOutput()
        {
            Settings setting = Settings.Instance();
            setting.YuiJsSettings.DisableOptimizations = false;
            setting.YuiJsSettings.IsObfuscateJavascript = true;
            setting.YuiJsSettings.PreserveAllSemiColons = true;
            setting.YuiJsSettings.LineBreakPosition = 0;
            setting.Save();

            string code = "function test(){\n var a=1; \n var b=2; \n } \n";
            code = TestEngine<Zippy.Chirp.Engines.YuiJsEngine>("c:\\test.js", code);

            Assert.IsTrue(code == "function test(){var c=1;var d=2;}");
            Assert.AreEqual(TaskList.Instance.Errors.Count(), 0);
        }

        [TestMethod]
        public void TestYuiJsEngineThrowTaskListErrorOnJsError()
        {
            this.YuiJsDefaultSetting();
            TaskList.Instance.RemoveAll();
            string code = "if(test  }";
            code = TestEngine<Zippy.Chirp.Engines.YuiJsEngine>("c:\\test.js", code);

            Assert.AreEqual(TaskList.Instance.Errors.Count(), 1);
        }
    }
}
