using System;
using System.Threading;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace GmailTelegramBot
{
    class Program
    {
        private static ITelegramBotClient botClient;

        static void Main(string[] args)
        {
            botClient = new TelegramBotClient(Configuration.Instance.TelegramSettings.BotToken);

            botClient.OnMessage += LogMessage;
            botClient.OnMessage += Echo;
            botClient.StartReceiving();
            
            while(true){}
        }

        static void LogMessage(object? sender, MessageEventArgs e)
        {
            var message = e.Message;
            Console.WriteLine(
                $"{message.From.FirstName} sent message {message.MessageId} " +
                $"to chat {message.Chat.Id} at {message.Date}."
            );
        }
        static async void Echo(object sender, MessageEventArgs e) {
            if (e.Message.Text != null)
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text:   "You said:\n" + e.Message.Text
                );
            }
        }
    }
}