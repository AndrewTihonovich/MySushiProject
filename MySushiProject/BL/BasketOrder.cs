using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.BL
{
    class BasketOrder : Sushi
    {
        public BasketOrder( string name, double coast, string description) : base ( name, coast, description)
        {
            AmountInOrder = 0;
            //CoastUnit = AmountInOrder * Coast;
        }

        public int AmountInOrder { get; set; }
        public double CoastUnit { get; set; }
        

        public override string ToString()
        {
            if (this.Name.Length > 15)
            {
                return $"\t{Name}\t\t{AmountInOrder}\t\t{Coast}\t\t{CoastUnit = Math.Round(AmountInOrder * Coast, 2)}\t        i";//Нажмите I
            }
            else
              {
                return $"\t{Name}\t\t\t{AmountInOrder}\t\t{Coast}\t\t{CoastUnit = Math.Round(AmountInOrder * Coast, 2)}\t        i";
              }
        }

      
    }
}
