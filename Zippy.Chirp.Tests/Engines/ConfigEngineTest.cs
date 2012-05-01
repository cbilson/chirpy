using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zippy.Chirp.Tests.Engines
{
    [TestClass]
    public class ConfigEngineTest :BaseTest
    {
        [TestMethod]
        public void TestLoadSettingFromEmptyConfig()
        {
            Settings setting = Settings.Instance();
            setting.ChirpConfigFile = ".chirp.config";
            setting.Save();

            File.WriteAllText("c:\\test.js", "alert('test');");

            string configFileName = "c:\\test.chirp.config";
            string xmlTest = "";
            File.WriteAllText(configFileName, xmlTest);

            Settings settingFromPath = Settings.Instance("c:\\test.js");

            Assert.IsTrue(settingFromPath.ChirpConfigFile == ".chirp.config");
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
        }

        [TestMethod]
        public void TestLoadSettingFromConfig()
        {
            Settings setting = Settings.Instance();
            setting.ChirpConfigFile = ".chirp.config";
            setting.Save();

            File.WriteAllText("c:\\test.js", "alert('test');");
            string configFileName = "c:\\test.chirp.config";
            string xmlTest = "<root><Settings><Setting key=\"ChirpSimpleJsFile\" value=\"testyy.js\"></Setting></Settings></root>";
            File.WriteAllText(configFileName, xmlTest);

            Settings settingFromPath = Settings.Instance("c:\\test.js");

            Assert.IsTrue(settingFromPath.ChirpSimpleJsFile == "testyy.js");
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
        }

        [TestMethod]
        public void TestLoadSettingFromConfig_KeyBadName()
        {
            Settings setting = Settings.Instance();
            setting.ChirpConfigFile = ".chirp.config";
            setting.ChirpSimpleJsFile = ".simple.js";
            setting.Save();

            File.WriteAllText("c:\\test.js", "alert('test');");
            string configFileName = "c:\\test.chirp.config";
            string xmlTest = "<root><Settings><Setting keyss=\"ChirpSimpleJsFile\" value=\"testyy.js\"></Setting></Settings></root>";
            File.WriteAllText(configFileName, xmlTest);

            Settings settingFromPath = Settings.Instance("c:\\test.js");

            Assert.IsTrue(settingFromPath.ChirpSimpleJsFile == ".simple.js");
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
        }

        [TestMethod]
        public void TestLoadSettingFromConfig_ValueBadName()
        {
            Settings setting = Settings.Instance();
            setting.ChirpConfigFile = ".chirp.config";
            setting.ChirpSimpleJsFile = ".simple.js";
            setting.Save();

            File.WriteAllText("c:\\test.js", "alert('test');");
            string configFileName = "c:\\test.chirp.config";
            string xmlTest = "<root><Settings><Setting key=\"ChirpSimpleJsFile\" valuess=\"testyy.js\"></Setting></Settings></root>";
            File.WriteAllText(configFileName, xmlTest);

            Settings settingFromPath = Settings.Instance("c:\\test.js");

            Assert.IsTrue(settingFromPath.ChirpSimpleJsFile == ".simple.js");
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
        }

        [TestMethod]
        public void TestLoadSettingFromConfig_ValueBadType()
        {
            Settings setting = Settings.Instance();
            setting.T4RunAsBuild = true;
            setting.Save();

            File.WriteAllText("c:\\test.js", "alert('test');");
            string configFileName = "c:\\test.chirp.config";
            string xmlTest = "<root><Settings><Setting key=\"T4RunAsBuild\" value=\"testyy.js\"></Setting></Settings></root>";
            File.WriteAllText(configFileName, xmlTest);

            Settings settingFromPath = Settings.Instance("c:\\test.js");

            Assert.IsTrue(settingFromPath.T4RunAsBuild == true);
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
        }

        [TestMethod]
        public void TestLoadSettingFromConfig_SetValueBool()
        {
            Settings setting = Settings.Instance();
            setting.T4RunAsBuild = true;
            setting.Save();

            File.WriteAllText("c:\\test.js", "alert('test');");
            string configFileName = "c:\\test.chirp.config";
            string xmlTest = "<root><Settings><Setting key=\"T4RunAsBuild\" value=\"false\"></Setting></Settings></root>";
            File.WriteAllText(configFileName, xmlTest);

            Settings settingFromPath = Settings.Instance("c:\\test.js");

            Assert.IsTrue(settingFromPath.T4RunAsBuild == false);
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
        }

        [TestMethod]
        public void TestConfigFileWithoutXmlNs()
        {
            File.WriteAllText("c:\\test.js", "alert('test');");
            string configFileName = "c:\\test.config";
            string xmlTest = "<root><FileGroup Name=\"scripts.combined.js\"><File Path=\"test.js\" Minify=\"false\" /></FileGroup></root>";
            File.WriteAllText(configFileName, xmlTest);

            TestActionEngine<Zippy.Chirp.Engines.ConfigEngine>(configFileName, xmlTest);

            Assert.IsTrue(File.Exists("c:\\scripts.combined.js"), "File group don't work");
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
            File.Delete("c:\\scripts.combined.js");
        }

        [TestMethod]
        public void TestConfigFileWithXmlNs()
        {
            File.WriteAllText("c:\\test.js", "alert('test');");
            string configFileName = "c:\\test.xml";
            string xmlTest = "<root xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"urn:ChirpyConfig\"><FileGroup Name=\"scripts.combined.js\"><File Path=\"test.js\" Minify=\"false\" /></FileGroup></root>";
            File.WriteAllText(configFileName, xmlTest);

            TestActionEngine<Zippy.Chirp.Engines.ConfigEngine>(configFileName, xmlTest);

            Assert.IsTrue(File.Exists("c:\\scripts.combined.js"), "File group don't work");
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
            File.Delete("c:\\scripts.combined.js");
        }

        [TestMethod]
        public void TestConfigFileGenerateFileWithDebugInName()
        {
            //workitem:134

            File.WriteAllText("c:\\test.js", "alert('test');");
            string configFileName = "c:\\test.xml";
            string xmlTest = "<root><FileGroup Name=\"podPlayers.debug.js\"><File Path=\"test.js\" Minify=\"false\" /></FileGroup><FileGroup Name=\"podPlayers.min.js\"><File Path=\"test.js\" Minify=\"true\" /></FileGroup></root>";
            File.WriteAllText(configFileName, xmlTest);

            TestActionEngine<Zippy.Chirp.Engines.ConfigEngine>(configFileName, xmlTest);

            Assert.IsTrue(File.Exists("c:\\podPlayers.debug.js"), "File group debug don't work");
            Assert.IsTrue(File.Exists("c:\\podPlayers.min.js"), "File group min don't work");
            File.Delete(configFileName);
            File.Delete("c:\\test.js");
            File.Delete("c:\\podPlayers.debug.js");
            File.Delete("c:\\podPlayers.min.js");
        }
    }
}
