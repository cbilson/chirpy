using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;
using Zippy.Chirp.JavaScript;

namespace Zippy.Chirp.Tests.JavaScript
{
    [TestClass]
    public class JsHintTest : BaseTest
    {
        [TestMethod]
        public void TestJSHintEvalIsEvil()
        {
            string code = "function test(){ eval(''); }";
            JSHint.result[] result;
            result = JSHint.JSHINT(code);

            result.Should().Not.Be.Null();
            result.Length.Should().Be.InRange(1, 9999);
            result[0].reason.Should().Contain("eval is evil");
        }

        [TestMethod]
        public void TestJSHintOK()
        {
            string code = "function test(){ }";
            JSHint.result[] result;
            result = JSHint.JSHINT(code);

            result.Should().Be.Null();
        }

        [TestMethod]
        public void TestJSHintOptions()
        {
            string code = "function test(){ if(true) return (/./).test(''); }";
            JSHint.result[] result;
            result = JSHint.JSHINT(code, new JSHint.options { regex = true, curly = true });
            result.Should().Not.Be.Null();
            result.Length.Should().Be.InRange(1, 9999);
            result[0].reason.Should().Contain("Expected '{'");
        }

        [TestMethod]
        public void CanRunMultipleTimes_JSHINT()
        {
            for (var j = 0; j < 10; j++)
                for (var i = 0; i < 10; i++)
                {
                    string code = "if(test==0){alert(1);}";
                    JSHint.JSHINT(code);
                }
        }

    }
}
