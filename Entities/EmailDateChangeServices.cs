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
        public static void EventDateChangedEmail(string userEmail, string eventName,DateTime date, string name)
        {
            var userName = string.IsNullOrEmpty(name.Trim())?"Sir/Madam":name;
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress("DateChangedInfo@gmail.com");
                    mail.To.Add(userEmail);
                    

                    mail.Subject = $"Date of event {eventName} Changed to {date.ToShortDateString()}";
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                    mail.Body = $"  <div><h4>Dear {userName},</h4><br/>" +
                        $"<p> We would like to inform you that your pennis has shrunk by 11 inches, please contact us for CHEAP pennis enlargemt methods.</p>" +
                        $"<p> Please visit us on {eventName} at the new date for further enlargement {date}</p>" +
                        "<p> Also the date  of your event has cahnged</p><p> With regards,</p><p> Money makes your pick bigger</p></div>";

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
        public static void NewEventMail(string userEmail, string eventName, DateTime? date, string name)
        {
            var userName = string.IsNullOrEmpty(name.Trim()) ? "Sir/Madam" : name;

            var isValidDate = DateTime.TryParse(date.ToString(), out DateTime someDate );

            var subject = isValidDate ? $"Date of event {eventName} Changed to {someDate.ToShortDateString()}" : $"New Cause {eventName}";

            var eventString = $"  <div><h4>Dear {userName},</h4><br/>" +
                              $"<p> We would like to inform you that a new event has been added.</p>" +
                              $"<p> Event {eventName} will be held on {date}, please follow if you like to assist!!!! </p>" +
                                "<p> With regards,</p><p> Money makes your pick bigger</p></div>";

            var causeString = $"  <div><h4>Dear {userName},</h4><br/>" +
                             $"<p> We would like to inform you that a new cause has been added.</p>" +
                             $"<p> Cause {eventName}, please follow if you like to assist!!!! </p>" +
                             "<p> With regards,</p><p> Money makes your pick bigger</p></div>";

            var body = isValidDate ? eventString : causeString;

            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress("DateChangedInfo@gmail.com");
                    mail.To.Add(userEmail);


                    mail.Subject = subject;
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                    mail.Body = body;

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
