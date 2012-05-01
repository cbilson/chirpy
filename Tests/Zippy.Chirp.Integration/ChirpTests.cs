using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Yahoo.Yui.Compressor;
using dotless.Core;
using dotless.Core.configuration;

namespace Zippy.Chirp.Tests
{
    [TestClass]
    public class ChirpTests
    {
        const string directoryPrefix = @"..\..\..\..\Tests\Zippy.Chirp.TestApp\";

        //File Text
        static string a_chirp_js;
        static string a_min_js;
        static string b_whitespace_js;
        static string b_min_js;
        static string c_yui_js;
        static string c_min_js;
        static string d_simple_js;
        static string d_min_js;
        static string x_js; //config
        static string z_js; //config
        static string a_chirp_css;
        static string a_min_css;
        static string b_chirp_less;
        static string b_css;
        static string b_min_css;
        static string x_css; //config

        
        //File Paths
        const string Error_chirp_js_path = @"scripts\error.chirp.js";
        const string a_chirp_js_path = @"scripts\a.chirp.js";
        const string a_min_js_path = @"scripts\a.min.js";
        const string b_whitespace_js_path = @"scripts\b.whitespace.js";
        const string b_min_js_path = @"scripts\b.min.js";
        const string c_yui_js_path = @"scripts\c.yui.js";
        const string c_min_js_path = @"scripts\c.min.js";
        const string d_simple_js_path = @"scripts\d.simple.js";
        const string d_min_js_path = @"scripts\d.min.js";
        const string x_js_path = @"scripts\x.js";
        const string z_js_path = @"scripts\z.js";
        const string a_chirp_css_path = @"styles\a.chirp.css";
        const string a_min_css_path = @"styles\a.min.css";
        const string b_chirp_less_path = @"styles\b.chirp.less";
        const string b_css_path = @"styles\b.css";
        const string b_min_css_path = @"styles\b.min.css";
        const string x_css_path = @"styles\x.css";

        [ClassInitialize()]
        public static void Init(TestContext context)
        {
            a_chirp_js = TextFromFile(a_chirp_js_path);
            a_min_js = TextFromFile(a_min_js_path);
            b_whitespace_js = TextFromFile(b_whitespace_js_path);
            b_min_js = TextFromFile(b_min_js_path);
            c_yui_js = TextFromFile(c_yui_js_path);
            c_min_js = TextFromFile(c_min_js_path);
            d_simple_js = TextFromFile(d_simple_js_path);
            d_min_js = TextFromFile(d_min_js_path);
            x_js = TextFromFile(x_js_path);
            z_js = TextFromFile(z_js_path);
            a_chirp_css = TextFromFile(a_chirp_css_path);
            a_min_css = TextFromFile(a_min_css_path);
            b_chirp_less = TextFromFile(b_chirp_less_path);
            b_css = TextFromFile(b_css_path);
            b_min_css = TextFromFile(b_min_css_path);
            x_css = TextFromFile(x_css_path);
        }

        #region "test Javascript"
        /// <summary>
        /// Test file is not found throw filenotfoundexception
        /// </summary>
        [TestMethod()]
        public void TestJSFileNotFound()
        {
            try
            {
                GoogleClosureCompiler.Compress("w:\test.js", ClosureCompilerCompressMode.SIMPLE_OPTIMIZATIONS);
            }
            catch (FileNotFoundException eError)
            { 
                
            }
            catch(Exception eError)
            {
                Assert.Fail("Wrong exception throw " + eError.GetType().ToString());
            }
        }

        [TestMethod()]
        public void TestJSThrowGoogleErrorJS()
        {
            try
            {
              string min=  GoogleClosureCompiler.Compress(FilePath(Error_chirp_js_path), ClosureCompilerCompressMode.WHITESPACE_ONLY);
               
            }
            catch (GoogleClosureCompilerErrorException  eError)
            {

            }
            catch (Exception eError)
            {
                Assert.Fail("Wrong exception throw " + eError.GetType().ToString());
            }
        }

        /// <summary>
        /// Test GoogleClosureCompiler too large
        /// </summary>
        [TestMethod()]
        public void TestJsFileA()
        {
            //a is too large for Google
            //so should be the same as YUI compressor
            string min = JavaScriptCompressor.Compress(a_chirp_js);
            Assert.IsTrue(a_min_js.Contains(min));
        }

        /// <summary>
        /// Test GoogleClosureCompiler mode WHITESPACE_ONLY
        /// </summary>
        [TestMethod()]
        public void TestJsFileB()
        {
            string file =FilePath(b_whitespace_js_path);
            string min = GoogleClosureCompiler.Compress(file,ClosureCompilerCompressMode.WHITESPACE_ONLY);
            Assert.AreEqual(min, b_min_js);
        }

        /// <summary>
        /// Test YUI compress
        /// </summary>
        [TestMethod()]
        public void TestJsFileC()
        {
            string min = JavaScriptCompressor.Compress(c_yui_js);
            Assert.AreEqual(min, c_min_js);
        }

        /// <summary>
        /// Test GoogleClosureCompiler mode SIMPLE_OPTIMIZATIONS
        /// </summary>
        [TestMethod()]
        public void TestJsFileD()
        {
            string file =FilePath(d_simple_js_path);
            string min = GoogleClosureCompiler.Compress(file,ClosureCompilerCompressMode.SIMPLE_OPTIMIZATIONS );
            Assert.AreEqual(d_min_js, min);
        }

        [TestMethod()]
        public void TestJsFileX()
        {
            Assert.IsTrue(x_js.Contains(a_min_js), "a");
            Assert.IsTrue(x_js.Contains(b_min_js), "b");
            Assert.IsTrue(x_js.Contains(c_min_js), "c");
            Assert.IsTrue(x_js.Contains(d_min_js), "d");
        }

        [TestMethod()]
        public void TestJsFileZ()
        {
            Assert.IsTrue(z_js.Contains(a_min_js), "a");
            Assert.IsTrue(z_js.Contains(b_min_js), "b");
            Assert.IsTrue(z_js.Contains(c_min_js), "c");
            Assert.IsTrue(z_js.Contains(d_min_js), "d");
        }



        #endregion

        #region "test CSS"
        [TestMethod()]
        public void TestCssFileA()
        {
            string min = CssCompressor.Compress(a_chirp_css);
            Assert.AreEqual(min, a_min_css);
        }

        [TestMethod()]
        public void TestCssFileB()
        {
            string css = LessToCss(b_chirp_less, b_chirp_less_path);
            Assert.AreEqual(css, b_css);
        }

        [TestMethod()]
        public void TestCssFileX()
        {
            Assert.IsTrue(x_css.Contains(a_min_css), "a");
            Assert.IsTrue(x_css.Contains(b_min_css), "b");
        }
        #endregion

        #region "test less"

        private static string LessToCss(string css, string fileName)
        {
            var current = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(new FileInfo(FilePath(fileName)).DirectoryName);

            var engine = new EngineFactory().GetEngine(new DotlessConfiguration
            {
                MinifyOutput = false
            });

            string cssText = engine.TransformToCss(new LessSourceObject
            {
                Content = css,
            });

            Directory.SetCurrentDirectory(current);
            return cssText;
        }

        #endregion

        private static string FilePath(string relFileName)
        {
            return Path.Combine(directoryPrefix, relFileName);
        }

        private static string TextFromFile(string relFileName)
        {
            string fileName = FilePath(relFileName);
            string file = File.ReadAllText(fileName);
            return file;
        }
    }
}
