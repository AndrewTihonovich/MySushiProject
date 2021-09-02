using MySushiProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Models
{
    class Order
    {
        public Guid Id { get; } = Guid.NewGuid();
        public List<BasketOrder> BasketOrders { get; set; }
        public User User { get; set; }
        public double TotalCoast { get; set; }
        public DateTime Date { get; set; }
        public bool isCompleted { get; set; } = false;
        public bool isDelivered { get; set; } = false;
        public bool isPaid { get; set; } = false;

        public override string ToString()
        {
            return $"{User} \n Заказ:\n {BasketOrders}\n Общая стоимость заказа {TotalCoast}";
        }





    }
}
