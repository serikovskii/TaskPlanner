using System;
using System.Net;
using System.Net.Mail;
using TaskPlanner.Abstract;

namespace TaskPlanner.Models
{
    public class Email : Entity
    {
        public string From { get; set; }
        public string To { get; set; }

        public async void Execute(string from1, string to1)
        {
            MailAddress from = new MailAddress(from1, "Azat");
            MailAddress to = new MailAddress(to1);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Test";
            m.Body = "Testing send message";
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 465);
            smtp.Credentials = new NetworkCredential(From, "AzatMukushman123");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}