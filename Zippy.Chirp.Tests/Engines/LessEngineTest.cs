using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zippy.Chirp.Engines;
using Zippy.Chirp.JavaScript;
using System.IO;

namespace Zippy.Chirp.Tests.Engines
{
	[TestClass]
	public class LessEngineTest :BaseTest
	{

		/*[TestMethod]
		public void TestLess()
		{
			string code = ".class { width: 1 + 1 }";
			var result = Less.render(code);
			Assert.AreEqual(result, ".class {\n  width: 2;\n}\n");
		}*/

		[TestMethod]
		public void TestLessDependencies()
		{
			var code = @"
					@import url(test/1);
					@import url('..\test\2');
					@import url(""/test/3"");
					@import '../test/4';
					@import ""./test/5"";              
				";

			var imports = LessEngine.FindDependencies("C:\\test\\temp\\0.less", code, "C:\\test\\");
			Assert.AreEqual(@"C:\test\temp\test\1.less".ToUri(), imports.ElementAtOrDefault(0));
			Assert.AreEqual(@"C:\test\test\2.less".ToUri(), imports.ElementAtOrDefault(1));
			Assert.AreEqual(@"C:\test\test\3.less".ToUri(), imports.ElementAtOrDefault(2));
			Assert.AreEqual(@"C:\test\test\4.less".ToUri(), imports.ElementAtOrDefault(3));
			Assert.AreEqual(@"C:\test\temp\test\5.less".ToUri(), imports.ElementAtOrDefault(4));
		}

//        [TestMethod]
//        public void TestLessDependenciesConfigEngine()
//        {
//            //workitem:122
//            var code = @"
//					@import url(test/1);
//					@import url('..\test\2');
//					@import url(""/test/3"");
//					@import '../test/4';
//					@import ""./test/5"";              
//				";

//            string filePath = @"c:\test.less";
//            File.WriteAllText(filePath, code);
//            var projectItem = base.GetProjectItem(filePath);

//            ConfigEngine config = new ConfigEngine();
//            config.ReloadFileDependencies(projectItem);
//            File.Delete(filePath);
//        }

		[TestMethod]
		public void TestLessEngine()
		{
			string code = "@x:1px; #test { border: solid @x #000; }";
			code = TestEngine<Zippy.Chirp.Engines.LessEngine>("c:\\test.css", code);
			Assert.IsTrue(code == "#test {\n  border: solid 1px black;\n}\n" || code == "#test{border:solid 1px #000;}");

		}

		[TestMethod]
		public void TestLessEngineError()
		{
			TaskList.Instance.RemoveAll();
			string code = "#test {\r\n\t color/**/ @ddddd : red; }";
			code = TestEngine<Zippy.Chirp.Engines.LessEngine>("c:\\test.css", code);
			Assert.AreEqual(TaskList.Instance.Errors.Count(), 1);
		}

		[TestMethod]
		public void TestLessEngineCompress()
		{
			Settings settings = Settings.Instance();
			settings.DotLessCompress = true;
			settings.Save();
			string codeOriginal = "@x:1px; #test {\n  border: solid @x #000;\n }\n\n\n";
			string codeResult = string.Empty;
			codeResult = TestEngine<Zippy.Chirp.Engines.LessEngine>("c:\\test.css", codeOriginal);
			Assert.IsTrue(codeResult.Contains("solid 1px #000}"));

		}

			[TestMethod]
		public void TestLessEngineNotCompress()
		{
			string codeOriginal = "@x:1px; #test {\n  border: solid @x #000;\n }\n\n\n";

			Settings settings = Settings.Instance();
		
			settings.DotLessCompress = false;
			settings.Save();
			string codeResult = TestEngine<Zippy.Chirp.Engines.LessEngine>("c:\\test.css", codeOriginal);
			Assert.IsTrue(codeResult == "#test {\n  border: solid 1px black;\n}\n");
		}
	}
}
