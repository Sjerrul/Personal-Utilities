using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Sjerrul.Utilities;

namespace MasterProject.Tests.Infrastructure
{
    [TestClass]
    public class SettingsTests
    {
        [TestMethod]
        public void Settings_Gets_Boolean()
        {
            AddConfigurationValue("boolean", "true");

            bool setting = Settings.Get<bool>("boolean");

            Assert.AreEqual(setting, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Settings_Throws_Error_when_key_not_found()
        { 
            bool setting = Settings.Get<bool>("Definately.Not.Present");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Settings_Throws_Error_when_key_has_no_value_for_all_but_string()
        {
            AddConfigurationValue("empty", "");
            bool setting = Settings.Get<bool>("empty");
        }

        [TestMethod]
        public void Settings_Throws_No_Error_when_key_has_no_value_for_string()
        {
            AddConfigurationValue("empty", "");
            string setting = Settings.Get<string>("empty");

            Assert.AreEqual(String.Empty, setting);
        }

        [TestMethod]
        public void Settings_Gets_String()
        {
            AddConfigurationValue("string", "teststring");

            string setting = Settings.Get<string>("string");

            Assert.AreEqual(setting, "teststring");
        }

        [TestMethod]
        public void Settings_Gets_Int()
        {
            AddConfigurationValue("integer", "5");

            int setting = Settings.Get<int>("integer");

            Assert.AreEqual(setting, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Settings_Throws_Error_On_Type_MisMatch()
        {
            AddConfigurationValue("boolean", "true");

            int setting = Settings.Get<int>("boolean");
        }

        private void AddConfigurationValue(string key, string value)
        {
            System.Configuration.Configuration config =  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            config.AppSettings.Settings.Remove(key);

            config.AppSettings.Settings.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

        }
    }
}
