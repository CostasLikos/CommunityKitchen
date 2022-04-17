using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class EmailDateChangeServices
    {
        public static void EventDateChangedEmail(string userEmail, string eventName,DateTime date)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress("DateChangedInfo@gmail.com");
                    mail.To.Add(userEmail);
                    

                    mail.Subject = $"Date of event {eventName} Changed to {date.ToShortDateString()}";
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                    mail.Body = $"<div>datechange email: Irthe to mail Malaka</div>";
                    mail.IsBodyHtml = true;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;

                    using (var smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.UseDefaultCredentials = false;

                        smtp.Credentials = new NetworkCredential("DateChangedInfo@gmail.com", "321SAdmin!");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        
                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }
    }
}
