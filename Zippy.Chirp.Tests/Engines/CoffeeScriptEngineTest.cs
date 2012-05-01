using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;
using Zippy.Chirp.JavaScript;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class CoffeeScriptEngineTest :BaseTest
    {
        [TestMethod]
        public void TestCoffeeScriptEngine()
        {
            string code = "alert \"Hello CoffeeScript!\"";
            string TempFilePath = System.Environment.CurrentDirectory + "\\test.js";
            System.IO.File.WriteAllText(TempFilePath, code);

            code = TestEngine<Zippy.Chirp.Engines.CoffeeScriptEngine>(TempFilePath, code);

            Assert.IsTrue(code.StartsWith("(function()"));
        }

        [TestMethod]
        public void TestCoffeeScript()
        {
            var code = "/*CoffeeScript: bare: true */\r\nalert 'hello!'";

            code = CoffeeScript.compile(code);

            code.Should().Contain("alert('hello!')");
            code.Should().Not.Contain("function");
        }
    }
}
