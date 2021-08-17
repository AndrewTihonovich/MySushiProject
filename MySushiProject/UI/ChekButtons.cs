using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.UI
{
    class ChekButtons
    {
        public static int CheckBut(int count, out bool but)
        {
            but = false;
            var keyL = ConsoleKey.LeftArrow;
            var keyR = ConsoleKey.RightArrow;
            var keyU = ConsoleKey.UpArrow;
            var keyD = ConsoleKey.DownArrow;
            var keyEnt = ConsoleKey.Enter;
            var keyEsc = ConsoleKey.Escape;

            var key = Console.ReadKey();

            if (key.Key == keyU)
            {
                count--;

            }

            if (key.Key == keyD)
            {
                count++;

            }

            if (key.Key == keyEnt)
            {

                but = true;

            }


            return count;
        }
    }
}
