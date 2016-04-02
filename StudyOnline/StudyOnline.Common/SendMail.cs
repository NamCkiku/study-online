using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Common
{
    public class SendMail
    {
        public static void SendGmail(string subject, string body, string myemail, string password, string emailTo, string myacount)
        {
            MailMessage message = new MailMessage();
            message.To.Add(emailTo);
            message.Subject = subject;
            message.Body = body;
            message.From = new MailAddress(myemail);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Credentials = new NetworkCredential(myacount, password);
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
        }
        public static string RandomString(int size)
        {
            Random rnd = new Random();
            string srds = "";
            string[] str = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            for (int i = 0; i < size; i++)
            {
                srds = srds + str[rnd.Next(0, 61)];
            }
            return srds;
        }
    }
}
