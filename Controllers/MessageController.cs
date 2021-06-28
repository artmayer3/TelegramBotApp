using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBotApp.Models;

namespace TelegramBotApp.Controllers
{
    [Route("api/message/update")]
    public class MessageController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Method GET unavailable";
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody] Update update)
        {
            if (update == null)
                return Ok();

            var commands = Bot.Commands;
            var message = update.Message ?? ConvertCallback(update.CallbackQuery);
            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            if(update.CallbackQuery != null)
            {
                await botClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);
            }
            return Ok();
        }
        private Message ConvertCallback(CallbackQuery callbackQuery)
        {
            var message = new Message
            {
                Text = callbackQuery.Data,
                Chat = callbackQuery.Message.Chat
            };
            return message;
        }
    }
}