using Newtonsoft.Json.Linq;
using System.IO;

namespace SqlRetrieve.Tests.Utils
{
    public static class ConfigLoader
    {
        public static string GetConnectionString()
        {
            var json = File.ReadAllText("settings.json");
            var config = JObject.Parse(json);
            return config["ConnectionString"]?.ToString();
        }
    }
}
