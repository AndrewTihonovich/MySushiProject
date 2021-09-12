using System;

namespace MySushiProject.Models
{
    class BasketOrder : Sushi
    {
        public BasketOrder(int id, string name, double coast, string description) : base ( id, name, coast, description)
        {
            AmountInOrder = 0;
        }

        public int AmountInOrder { get; set; }
        public double CoastUnit { get; set; }
        
    }
}
