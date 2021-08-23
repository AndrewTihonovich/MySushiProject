using MySushiProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.BL
{
    class Order
    {
        public Guid Id { get; } = Guid.NewGuid();
        public List<BasketOrder> BasketOrders { get; set; }
        public User User { get; set; }
        public double TotalCoast { get; set; }
    }
}
