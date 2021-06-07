using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace JobViteAutomationChallenge.Helper
{
    public class ConfigurationHelper
    {
        static string configPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string GetConfigValue(string property)
        {
            var json = JsonDocument.Parse(File.ReadAllText($"{configPath}/appsettings.json"));
            return json.RootElement.GetProperty(property).GetString();
        }
    }
}
