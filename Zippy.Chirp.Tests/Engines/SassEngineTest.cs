using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zippy.Chirp.Tests.Engines
{
	[TestClass]
	public class SassEngineTest :BaseTest
	{
		[TestMethod]
		public void TestScssVariables()
		{
			var input = @"$blue: #3bbfce;
$margin: 16px;

.content-navigation {
  border-color: $blue;
  color:
	darken($blue, 9%);
}

.border {
  padding: $margin / 2;
  margin: $margin / 2;
  border-color: $blue;
}";

			var result = ".content-navigation {\n  border-color: #3bbfce;\n  color: #2ca2af; }\n\n.border {\n  padding: 8px;\n  margin: 8px;\n  border-color: #3bbfce; }\n";

			string code = SasscompileInput("test.scss", input);
			Assert.AreEqual(result, code);
		}


		[TestMethod]
		public void TestScssSmoke()
		{
			var input = @"
			// SCSS

			.error {
			  border: 1px #f00;
			  background: #fdd;
			}
			.error.intrusion {
			  font-size: 1.3em;
			  font-weight: bold;
			}

			.badError {
			  @extend .error;
			  border-width: 3px;
			}
			";

			string code = SasscompileInput("test.scss", input);
			Assert.IsFalse(string.IsNullOrWhiteSpace(code));
		}

		[TestMethod]
		public void TestSassNegativeSmoke()
		{
			var input = ".foo bar[val=\"//\"] { baz: bang; }";
			try
			{
				string code = SasscompileInput("test.sass", input);
			}
			catch (Exception e)
			{
				Assert.IsTrue(e.ToString().Contains("Syntax"));
			}
		}

		string SasscompileInput(string filename, string input)
		{
			using (var of = File.CreateText(filename))
			{
				of.Write(input);
			}
			try
			{

				// TODO: Fix this
				//     fixture.Init(TODO);
				string result = TestEngine<Zippy.Chirp.Engines.SassEngine>(filename, input);
				Console.WriteLine(result);
				return result;
			}
			finally
			{
				File.Delete(filename);
			}
		}
	}
}
