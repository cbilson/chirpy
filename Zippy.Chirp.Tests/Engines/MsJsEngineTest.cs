using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class MsJsEngineTest : BaseTest
    {
        private void MsJsDefaultSetting()
        {
            Settings setting = Settings.Instance();
            setting.Save();
        }

        [TestMethod]
        public void TestMsJsEngine()
        {
            this.MsJsDefaultSetting();
            string code = "if(test) {\r\n\t alert('test'); }";
            code = TestEngine<Zippy.Chirp.Engines.MsJsEngine>("c:\\test.js", code);

            Assert.IsTrue(code.Equals("test&&alert(\"test\")") || code.Equals("test && alert(\"test\")") || code.Equals("test && alert(\"test\");"));
        }

        [TestMethod]
        public void TestMsJsEngineThrowTaskListErrorOnJsError()
        {
            this.MsJsDefaultSetting();
            TaskList.Instance.RemoveAll();
            string code = "if(test){;";
            code = TestEngine<Zippy.Chirp.Engines.MsJsEngine>("c:\\test.js", code);

            Assert.AreEqual(TaskList.Instance.Errors.Count(), 1);
        }
    }
}
