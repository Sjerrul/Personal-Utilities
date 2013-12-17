using System;
using System.Configuration;

namespace Sjerrul.Utilities
{
    public static class Settings
    {
        public static T Get<T>(string settingKey)
        {  
            string value = ConfigurationManager.AppSettings[settingKey];

            if (String.IsNullOrWhiteSpace(value) && typeof(T) != typeof(string))
            {
                throw new ArgumentException(String.Format("The key '{0}' is not found in the AppSettings", settingKey));
            }

            T castedValue = (T)Convert.ChangeType(value, typeof(T));

            return castedValue;
        }
    }
}
