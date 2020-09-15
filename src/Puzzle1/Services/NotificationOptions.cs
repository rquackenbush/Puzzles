namespace Puzzle1.Services
{
    public class NotificationOptions
    {
        public string FromEmailAddress { get; set; }

        public string ToEmailAddress { get; set; }

        public string SmtpServerAddress { get; set; }

        public int SmtpServerPort { get; set; } = 587;

        public bool EnableSsl { get; set; } = true;

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
