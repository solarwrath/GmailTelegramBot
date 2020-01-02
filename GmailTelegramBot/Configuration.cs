using System.IO;
using Newtonsoft.Json;

namespace GmailTelegramBot
{
    public sealed class Configuration
    {
        public TelegramSettings TelegramSettings { get; set; }

        private const string ConfigurationFileName = "config.json";
        private static Configuration _instance;

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(ConfigurationFileName));
                }

                return _instance;
            }
        }

        private Configuration()
        {
        }
    }
}