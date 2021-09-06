using MySushiProject.Models;

namespace MySushiProject.Sender
{
    abstract class EmailSender
    {
        
        public static void OrderComplited(Order order)
        {
            //send Email
            
            Logger.Log.logger.Itfo($"Email OrderComplited {order.User} is Send");

            order.Dispose();
        }

        public static void OrderDelivered(Order order)
        {
            //send Email

            Logger.Log.logger.Itfo($"Email OrderDelivered {order.User} is Send");

            order.Dispose();
        }

        public static void OrderPaid(Order order)
        {
            //send Email

            Logger.Log.logger.Itfo($"Email OrderPaid {order.User} is Send");

            order.Dispose();
        }
    }
}
