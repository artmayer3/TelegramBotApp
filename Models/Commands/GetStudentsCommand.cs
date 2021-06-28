using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.Callbacks;
using System.Linq;

namespace TelegramBotApp.Models.Commands
{
    class GetStudentsCommand : Command
    {
        public override string Name => @"/getStudents";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(Name);
        }

        private List<string> GetStudents()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://ip/api/Raspberry");

            var headers = new WebHeaderCollection
            {
                "Authorization:HelloWorld"
            };
            request.Headers = headers;

            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.ContentType = "application/json";
            //request.MediaType = "application/json";
            //request.Accept = "application/json";

            var listAttendance = new List<Attendance>();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        listAttendance = JsonConvert.DeserializeObject<List<Attendance>>(reader.ReadToEnd());
                    }
                }
            }

            var result = listAttendance.Select(c => $"ФИ студента: {c.Studentname} \nНомер карты студента: {c.CardId}  \n[{c.Timestamp.Day}.{c.Timestamp.Month:00} {c.Timestamp.Hour}:{c.Timestamp.Minute}]").ToList();

            return result;
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, string.Join("\n\n", GetStudents()), replyMarkup: HandlingCallbacks.Keyboard);
        }
    }
}
