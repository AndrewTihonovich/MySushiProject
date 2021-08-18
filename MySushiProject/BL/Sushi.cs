using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.BL
{
    class Sushi
    {
        //static int id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public int AmountPortion { get; set; }
        public double CoastUnit { get; set; }

        public Sushi( int id, string name, int amountPortion, double coastUnit)
        {
            //id++;
            Id = id;
            Name = name;
            AmountPortion = amountPortion;
            CoastUnit = coastUnit;
        }

    }
}
