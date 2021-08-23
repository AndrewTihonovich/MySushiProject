using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.BL
{
    [Obsolete]
    class ListSushi
    {
        Sushi mysu = new Sushi("erbgkjbg", 15, "description");
        BasketOrder basket = new BasketOrder("jdhjfjg", 5, "description");
        

        
        public List<BasketOrder> SushiList()
        {
            List<BasketOrder> orders = new List<BasketOrder>();


            //orders.Add(new BasketOrder(1, "Аризона", 14));
            //orders.Add(new BasketOrder(2, "Аризона", 4));
            //orders.Add(new BasketOrder(3, "Аризона", 8));
            //orders.Add(new BasketOrder(4, "Аризона", 10));
            //orders.Add(new BasketOrder(5, "Аризона", 8));
            //orders.Add(new BasketOrder(6, "Аризона", 16));
            //orders.Add(new BasketOrder(7, "Аризона", 20));
            //orders.Add(new BasketOrder(8, "Аризона", 14));
            //orders.Add(new BasketOrder(9, "Аризона", 6));

            return orders;
        }

        public static double TotalCoast(List<BasketOrder> orders)
        {
            double totalCoast = 0;
            foreach (var item in orders)
            {
                if (item.CoastUnit !=0)
                {
                    totalCoast = Math.Round(totalCoast + item.CoastUnit, 2);
                }
            }
            
            return totalCoast;
        }
    }
}
