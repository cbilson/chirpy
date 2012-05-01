using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class DeanEdwardsPackerEngineTest:BaseTest
    {
        [TestMethod]
        public void TestDeanEdwardsPackerEngine()
        {
            string code = "alert('test');";
            code = TestEngine<Zippy.Chirp.Engines.DeanEdwardsPackerEngine>("c:\\test.js", code);

            Assert.IsTrue(code.StartsWith("eval(function",System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
