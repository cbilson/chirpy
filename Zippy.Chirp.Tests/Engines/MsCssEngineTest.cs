using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class MsCssEngineTest :BaseTest
    {
        private void MsCssDefaultSetting()
        {
            Settings setting = Settings.Instance();
            setting.Save();
        }

        /// <summary>
        /// Test Microsoft Ajax Minifer (javascript)
        /// </summary>
        [TestMethod]
        public void TestMsCssEngine()
        {
            this.MsCssDefaultSetting();
            string code = "#test {\r\n\t color  : red; }";
            code = TestEngine<Zippy.Chirp.Engines.MsCssEngine>("c:\\test.css", code);

            Assert.IsTrue(code.Equals("#test{color:red}") || code.Equals("#test{color:red;}"));
        }
    }
}
