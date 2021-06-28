using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotApp.Models.Callbacks
{
    public class HandlingCallbacks
    {
        public static InlineKeyboardMarkup Keyboard
        {
            get
            {
                var urlButton = new InlineKeyboardButton
                {
                    Text = "Получить список студентов",
                    CallbackData = "/getStudents"
                };
                var urlButton2 = new InlineKeyboardButton
                {
                    Text = "Ещё что-то"
                };
                var urlButton3 = new InlineKeyboardButton
                {
                    Text = "Ссылка на что-то не очень интересное...",
                    Url = "https://utmn.ru/"
                };

                // Rows, every row is InlineKeyboardButton[], You can put multiple buttons!
                InlineKeyboardButton[] row1 = new InlineKeyboardButton[] { urlButton/*, urlButton2*/ };
                InlineKeyboardButton[] row2 = new InlineKeyboardButton[] { urlButton3 };


                // Buttons by rows
                var buttons = new InlineKeyboardButton[][] { row1, row2 };
                var keyboard = new InlineKeyboardMarkup(buttons);

                return keyboard;
            }
        }
    }
}
