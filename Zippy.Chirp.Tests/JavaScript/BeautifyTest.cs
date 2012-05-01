using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;
using Zippy.Chirp.JavaScript;

namespace Zippy.Chirp.Tests.JavaScript
{
    [TestClass]
    public class BeautifyTest
    {
        [TestMethod]
        public void CanBeautify()
        {
            string minid, code = "if(test==0){alert(1);}";
            minid = Beautify.js_beautify(code);

            minid.Length.Should().Be.InRange(code.Length, int.MaxValue);
        }

        [TestMethod]
        public void BeautifyBadCode()
        {
            string minid, code = "----*&;lij;{lo23i41";
            try
            {
                minid = Beautify.js_beautify(code);

            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine(ex);
            }

        }
    }
}
