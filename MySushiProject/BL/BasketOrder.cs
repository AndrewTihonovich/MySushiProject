using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.BL
{
    class BasketOrder : Sushi
    {
        public BasketOrder(int amountInOrder, double coastPortion, int id, string name, int amountPortion, double coastUnit) : base (id, name, amountPortion, coastUnit)
        {
            AmountInOrder = amountInOrder;
            CoastPortion = coastPortion;
        }

        public int AmountInOrder { get; set; }
        public double CoastPortion { get; set; }
    }
}
