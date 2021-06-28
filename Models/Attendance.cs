using System;

namespace TelegramBotApp.Models
{
    class Attendance
    {
        public int? Id { get; set; }
        public string Studentname { get; set; }
        public int? CardId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Teachername { get; set; }
    }
}
