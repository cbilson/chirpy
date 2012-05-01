using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;
using Zippy.Chirp.JavaScript;

namespace Zippy.Chirp.Tests.JavaScript
{
    [TestClass]
    public class CSSLintTest:BaseTest
    {
        [TestMethod]
        public void TestCSSLint()
        {
            /*  Settings settings = new Settings();
              settings.CssLintOptions.AdjoiningClasses = true;
              settings.CssLintOptions.BoxModel=true;
              settings.CssLintOptions.CompatibleVendorPrefixes = true;
              settings.CssLintOptions.DisplayPropertyGrouping = true;
              settings.CssLintOptions.DuplicateProperties = true;
              settings.CssLintOptions.EmptyRules = true;
              settings.CssLintOptions.Floats = true;
              settings.CssLintOptions.FontFaces = true;
              settings.CssLintOptions.FontSizes = true;
              settings.CssLintOptions.Gradients = true;
              settings.CssLintOptions.Ids = true;
              settings.CssLintOptions.Import = true;
              settings.CssLintOptions.Important = true;
              settings.CssLintOptions.QualifiedHeadings = true;
              settings.CssLintOptions.RegexSelectors = true;
              settings.CssLintOptions.UniqueHeadings = true;
              settings.CssLintOptions.VendorPrefix = true;
              settings.CssLintOptions.ZeroUnits = true;
              settings.Save();*/

            using (var csslint = new CSSLint())
            {
                var result = csslint.CSSLINT(@"body {text-align:center;}
.container {text-align:left;}
* html .column, * html .span-1, * html .span-2, * html .span-3, * html .span-4, * html .span-5, * html .span-6, * html .span-7, * html .span-8, * html .span-9, * html .span-10, * html .span-11, * html .span-12, * html .span-13, * html .span-14, * html .span-15, * html .span-16, * html .span-17, * html .span-18, * html .span-19, * html .span-20, * html .span-21, * html .span-22, * html .span-23, * html .span-24 {display:inline;overflow-x:hidden;}
* html legend {margin:0px -8px 16px 0;padding:0;}
sup {vertical-align:text-top;}
sub {vertical-align:text-bottom;}
html>body p code {*white-space:normal;}
hr {margin:-8px auto 11px;}
img {-ms-interpolation-mode:bicubic;}
.clearfix, .container {display:inline-block;}
* html .clearfix, * html .container {height:1%;}
fieldset {padding-top:0;}
legend {margin-top:-0.2em;margin-bottom:1em;margin-left:-0.5em;}
textarea {overflow:auto;}
label {vertical-align:middle;position:relative;top:-0.25em;}
input.text, input.title, textarea {background-color:#fff;border:1px solid #bbb;}
input.text:focus, input.title:focus {border-color:#666;}
input.text, input.title, textarea, select {margin:0.5em 0;}
input.checkbox, input.radio {position:relative;top:.25em;}
form.inline div, form.inline p {vertical-align:middle;}
form.inline input.checkbox, form.inline input.radio, form.inline input.button, form.inline button {margin:0.5em 0;}
button, input.button {position:relative;top:0.25em;}");

                Console.Write(result);

                csslint.CSSLINT(".test { }").messages.Length.Should().Equal(1);
                csslint.CSSLINT(".test { color: red; }").messages.Length.Should().Equal(0);
            }
        }

        [TestMethod]
        public void TestCSSLintWithOptionIdsTrue()
        {
            CSSLint.options options = new CSSLint.options();
            options.Ids = true;

            using (var csslint = new CSSLint())
            {
                var result = csslint.CSSLINT("#fieldset {padding-top:0;}", options);

                Console.Write(result);

                Assert.AreEqual(1, result.messages.Length);
                result.messages[0].message.Should().Contain("Don't use IDs in selectors.");

            }

        }

        [TestMethod]
        public void TestCSSLintWithOptionIdsTwoTimeCall()
        {
            CSSLint.options options = new CSSLint.options();
            options.Ids = true;

            using (var csslint = new CSSLint())
            {
                var result = csslint.CSSLINT("#fieldset {padding-top:0;}", options);

                Assert.AreEqual(result.messages.Length, 1);
                Assert.AreEqual("Don't use IDs in selectors.", result.messages[0].message);

                options.Ids = false;

                var resultTimeTwo = csslint.CSSLINT("#fieldset {padding-top:0;}", options);
                Assert.AreEqual(0, resultTimeTwo.messages.Length);
            }

        }

        [TestMethod]
        public void TestCSSLintManyTimeCall()
        {
            using (var csslint = new CSSLint())
            {
                for (int i = 0; i <= 300; i++)
                {
                    var result = csslint.CSSLINT("body {padding-top:0;}");
                    Assert.AreEqual(0, result.messages.Length);
                }
            }
        }

        [TestMethod]
        public void TestCSSLintWithOptionIdsFalse()
        {
            CSSLint.options options = new CSSLint.options();
            options.Ids = false;

            using (var csslint = new CSSLint())
            {
                var result = csslint.CSSLINT("#fieldset {padding-top:0;}", options);

                Console.Write(result);

                Assert.AreEqual(0, result.messages.Length);
            }

        }

     
    }
}
