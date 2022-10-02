using System.Configuration;

namespace Selenium.Framework
{
    public class Configuration
    {
        public static string GetConfigs(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        public static string Browser => GetConfigs("browser", "chrome");
        public static string URL => GetConfigs("url", "https://qaautomation-test.s3-eu-west-1.amazonaws.com/index.html");
    }
}
