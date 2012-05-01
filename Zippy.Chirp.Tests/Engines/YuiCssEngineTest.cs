using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zippy.Chirp.Engines;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class YuiCssEngineTest : BaseTest
    {
        private void YuiCssDefaultSetting()
        {
            Settings setting = Settings.Instance();
            setting.YuiCssSettings.ColumnWidth = 0;
            setting.YuiCssSettings.RemoveComments = true;
            setting.Save();
        }

        [TestMethod]
        public void TestYuiCssEngine()
        {
            this.YuiCssDefaultSetting();

            string code = "#test {\r\n\t color  : red; }";
            code = TestEngine<YuiCssEngine>("c:\\test.css", code);

            Assert.AreEqual(code, "#test{color:red}");
        }

        [TestMethod]
        public void TestYuiMARECssEngine()
        {
            this.YuiCssDefaultSetting();

            string code = "#test {\r\n\t color  : #ffffff; }";
            string output = YuiCssEngine.Minify(code, Zippy.Chirp.Xml.MinifyType.yuiMARE);

            Assert.AreEqual(output, "#test{color:#fff}");
        }

        [TestMethod]
        public void TestYuiHybridCssEngine()
        {
            this.YuiCssDefaultSetting();

            string code = "#test {\r\n\t color  : #ffffff; }";
            string output = YuiCssEngine.Minify(code, Zippy.Chirp.Xml.MinifyType.yuiHybrid);

            Assert.AreEqual(output, "#test{color:#fff}");
        }
    }
}
