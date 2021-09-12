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

            SendEmailAsync(order, status).GetAwaiter();
            
            Log.logger.Info($"Письмо \"Заказ {status}\" отправленно пользователю");

            order.Dispose();
        }

        public static void OrderDelivered(Order order)
        {
            string status = "доставлен курьером";

            SendEmailAsync(order, status).GetAwaiter();

            Log.logger.Info($"Письмо \"Заказ {status}\" отправленно пользователю");

            order.Dispose();
        }

        public static void OrderPaid(Order order)
        {
            string status = "оплачен";

            SendEmailAsync(order, status).GetAwaiter();

            Log.logger.Info($"Письмо \"Заказ {status}\" отправленно пользователю");

            order.Dispose();
        }

        private static async Task SendEmailAsync(Order order, string status)
        {
            MailAddress from = new MailAddress("SushiService2021@google.com", "SushiService");
            MailAddress to = new MailAddress($"{order.User.Email}"); //order.User.Email   AndrewT_87@tut.by
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = $"Заказ № {order.Id}";
            mail.Body = $"{order.User.Name}, Ваш заказ:\n" +
                        $"{order.BasketOrdersToString()}" +
                        $"Общая стоимость: {order.TotalCoast} бел.руб.\n" +
                        $"\nСтатус заказа:  {status}";
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("SushiService2021", "MySushi2021");
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                await smtp.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Log.logger.Error($"Ошибка при отправки почты: {ex.Message}");
            }
        }
    }
}
