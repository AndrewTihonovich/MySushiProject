using MySushiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Sender
{
    abstract class EmailSender
    {
        
        //RepoOrder RepoOrder = new RepoOrder();

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
