using System;
using Newtonsoft.Json;

namespace GmailTelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Configuration.Instance.TelegramSettings.BotToken);
        }
    }
}