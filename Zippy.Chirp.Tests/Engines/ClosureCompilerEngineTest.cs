using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zippy.Chirp.Engines;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class ClosureCompilerEngineTest:BaseTest
    {
        [TestMethod]
        public void TestClosureCompilerJsEngine()
        {
            string code = "if(test) {\r\n\t alert('test'); }";
            //create file for googleClosureCompilerOffline
            string TempFilePath = System.Environment.CurrentDirectory + "\\test.js";
            System.IO.File.WriteAllText(TempFilePath, code);

            code = TestEngine<Zippy.Chirp.Engines.ClosureCompilerEngine>(TempFilePath, code);

            Assert.IsTrue(code == "if(test)alert(\"test\");" || code == "if(test)alert(\"test\");\r\n");
        }

        [TestMethod]
        public void TestClosureCompilerAdvancedOfflineJsEngine()
        {
            Settings settings = new Settings();
            settings.GoogleClosureOffline = true;
            settings.Save();

            string code = "function hello(name) {alert('Hello, ' + name);}hello('New user');";
            //create file for googleClosureCompilerOffline
            string TempFilePath = System.Environment.CurrentDirectory + "\\test.js";
            System.IO.File.WriteAllText(TempFilePath, code);


            code = Zippy.Chirp.Engines.ClosureCompilerEngine.Minify(TempFilePath, code, GetProjectItem(TempFilePath), ClosureCompilerCompressMode.ADVANCED_OPTIMIZATIONS, string.Empty);
            Assert.IsTrue(code == "alert(\"Hello, New user\");\r\n");
        }

        [TestMethod]
        public void TestClosureCompilerAdvancedOnlineJsEngine()
        {
            Settings settings = new Settings();
            settings.GoogleClosureOffline = false;
            settings.Save();

            string code = "function hello(name) {alert('Hello, ' + name);}hello('New user');";
            //create file for googleClosureCompilerOffline
            string TempFilePath = System.Environment.CurrentDirectory + "\\test.js";
            System.IO.File.WriteAllText(TempFilePath, code);


            code = Zippy.Chirp.Engines.ClosureCompilerEngine.Minify(TempFilePath, code, GetProjectItem(TempFilePath), ClosureCompilerCompressMode.ADVANCED_OPTIMIZATIONS, string.Empty);
            Assert.IsTrue(code == "alert(\"Hello, New user\");\r\n" || code == "alert(\"Hello, New user\");");
        }

        [TestMethod]
        public void TestClosureCompilerAdvancedOnlineDetectFileName()
        {
            Settings settings = new Settings();
            settings.GoogleClosureOffline = false;
            settings.ChirpJsFile = ".chirp.js";
            settings.Save();

            string code = "function hello(name) {alert('Hello, ' + name);}hello('New user');";
            //create file for googleClosureCompilerOffline
            string TempFilePath = System.Environment.CurrentDirectory + "\\test.chirp.js";
            System.IO.File.WriteAllText(TempFilePath, code);

            ClosureCompilerEngine closureCompilerEngine = new ClosureCompilerEngine();
            code = closureCompilerEngine.Transform(TempFilePath, code, GetProjectItem(TempFilePath));
            Assert.IsTrue(code == "alert(\"Hello, New user\");\r\n" || code == "alert(\"Hello, New user\");");
        }

        [TestMethod]
        public void TestClosureCompilerSimpleJsEngine()
        {
            string code = "if(test) {\r\n\t alert('test'); }";
            //create file for googleClosureCompilerOffline
            string TempFilePath = System.Environment.CurrentDirectory + "\\test.js";
            System.IO.File.WriteAllText(TempFilePath, code);

            code = Zippy.Chirp.Engines.ClosureCompilerEngine.Minify(TempFilePath, code, GetProjectItem(TempFilePath), ClosureCompilerCompressMode.SIMPLE_OPTIMIZATIONS, string.Empty);
            Assert.IsTrue(code == "test&&alert(\"test\");" || code == "test&&alert(\"test\");\r\n");
        }


        [TestMethod]
        public void TestClosureCompilerWhiteSpaceOnlyJsEngine()
        {
            string code = "if(test) {\r\n\t alert('test'); }";
            //create file for googleClosureCompilerOffline
            string TempFilePath = System.Environment.CurrentDirectory + "\\test.js";
            System.IO.File.WriteAllText(TempFilePath, code);

            code = Zippy.Chirp.Engines.ClosureCompilerEngine.Minify(TempFilePath, code, GetProjectItem(TempFilePath), ClosureCompilerCompressMode.WHITESPACE_ONLY, string.Empty);
            Assert.IsTrue(code == "if(test)alert(\"test\");" || code == "if(test)alert(\"test\");\r\n");
        }

        [TestMethod]
        public void TestClosureCompilerJsEngineThrowTaskListErrorOnJsError()
        {
            TaskList.Instance.RemoveAll();
            string code = "if(test  }";
            //create file for googleClosureCompilerOffline
            string TempFilePath = System.Environment.CurrentDirectory + "\\test.js";
            System.IO.File.WriteAllText(TempFilePath, code);

            code = TestEngine<Zippy.Chirp.Engines.ClosureCompilerEngine>(TempFilePath, code);

            Assert.AreEqual(TaskList.Instance.Errors.Count(), 1);
        }
    }
}
