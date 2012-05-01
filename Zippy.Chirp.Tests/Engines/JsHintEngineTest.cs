using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class JsHintEngineTest :BaseTest
    {
        [TestMethod]
        public void TestJsHintEngine()
        {
            Settings settings = new Settings();
            settings.JsHintOptions.bitwise = true;
            settings.JsHintOptions.boss = true;
            settings.JsHintOptions.curly = true;
            settings.JsHintOptions.debug = true;
            settings.JsHintOptions.devel = true;
            settings.JsHintOptions.eqeqeq = true;
            settings.JsHintOptions.evil = true;
            settings.JsHintOptions.forin = true;
            settings.JsHintOptions.immed = true;
            settings.JsHintOptions.laxbreak = true;
            settings.JsHintOptions.maxerr = 25;
            settings.JsHintOptions.newcapp = true;
            settings.JsHintOptions.noarg = true;
            settings.JsHintOptions.noempty = true;
            settings.JsHintOptions.nomen = true;
            settings.JsHintOptions.nonew = true;
            settings.JsHintOptions.novar = true;
            settings.JsHintOptions.passfail = true;
            settings.JsHintOptions.plusplus = true;
            settings.JsHintOptions.regex = true;
            settings.JsHintOptions.strict = true;
            settings.JsHintOptions.sub = true;
            settings.JsHintOptions.undef = true;
            settings.JsHintOptions.white = true;
            settings.Save();

            string code = "if(test) {\r\n\t eval('test'); }";
            var filename = System.IO.Path.GetTempFileName();
            try
            {
                System.IO.File.WriteAllText(filename, code);
                using (var jshint = new Zippy.Chirp.Engines.JSHintEngine())
                {
                    jshint.Run(filename, GetProjectItem(filename));
                    Assert.AreNotEqual(0, TaskList.Instance.Errors.Count());
                }
            }
            finally
            {
                System.IO.File.Delete(filename);
            }
        }

    }
}
