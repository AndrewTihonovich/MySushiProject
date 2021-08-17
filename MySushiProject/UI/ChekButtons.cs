using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.UI
{
    class ChekButtons
    {
        public static ConsoleKey CheckBut()
        {
            //var keyL = ConsoleKey.LeftArrow;
            //var keyR = ConsoleKey.RightArrow;
            //var keyU = ConsoleKey.UpArrow;
            //var keyD = ConsoleKey.DownArrow;
            //var keyEnt = ConsoleKey.Enter;
            //var keyEsc = ConsoleKey.Escape;

            var key = Console.ReadKey();

            return key.Key;
        }


    }
}
