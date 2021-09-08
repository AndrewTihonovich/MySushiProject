using MySushiProject.Logger;
using MySushiProject.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MySushiProject.Sender
{
    abstract class EmailSender
    {
        
        public static void OrderComplited(Order order)
        {
            string status = "скомплектован";

            //send Email
            SendEmailAsync(order, status).GetAwaiter();
            
            Log.logger.Info($"Email OrderComplited {order.User} is Send");

            //order.Dispose();
        }

        public static void OrderDelivered(Order order)
        {
            string status = "доставлен курьером";

            //send Email
            SendEmailAsync(order, status).GetAwaiter();

            Log.logger.Info($"Email OrderDelivered {order.User} is Send");

            //order.Dispose();
        }

        public static void OrderPaid(Order order)
        {
            string status = "оплачен";

            //send Email
            SendEmailAsync(order, status).GetAwaiter();

            Log.logger.Info($"Email OrderPaid {order.User} is Send");

            order.Dispose();
        }

        //public static void SendEmail(Order order, string status)
        //{
        //    MailAddress from = new MailAddress("SushiService2021@google.com", "SushiService");
        //    MailAddress to = new MailAddress("AndrewT_87@tut.by"); //order.User.Email
        //    MailMessage mail = new MailMessage(from, to);
        //    mail.Subject = $"Заказ № {order.Id}";
        //    mail.Body = $"{order.User.Name}, Ваш заказ {status}";
        //    mail.IsBodyHtml = false;

        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //    smtp.Credentials = new NetworkCredential("SushiService2021", "MySushi2021");
        //    smtp.EnableSsl = true;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtp.Send(mail);

        //}

        private static async Task SendEmailAsync(Order order, string status)
        {
            MailAddress from = new MailAddress("SushiService2021@google.com", "SushiService");
            MailAddress to = new MailAddress("AndrewT_87@tut.by"); //order.User.Email
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = $"Заказ № {order.Id}";
            mail.Body = $"{order.User.Name}, Ваш заказ {status}";
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("SushiService2021", "MySushi2021");
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(mail);
        }



    }

}
