using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotApp.Models.Commands;

namespace TelegramBotApp.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>
            {
                new StartCommand(),
                new HelpCommand(),
                new GetStudentsCommand()
            };
            //TODO: Add more commands

            botClient = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}