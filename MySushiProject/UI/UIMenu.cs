using MySushiProject.UI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.UI
{
    class UIMenu
    {
        //static bool isEnter = false;
        public static EnumListMenu UiMenus(List<string> Menu, string message, EnumListMenu listMenu)
        {
            ConsoleKey butNumber=0;
            var keyL = ConsoleKey.LeftArrow;
            var keyR = ConsoleKey.RightArrow;
            var keyU = ConsoleKey.UpArrow;
            var keyD = ConsoleKey.DownArrow;
            var keyEnt = ConsoleKey.Enter;
            var keyEsc = ConsoleKey.Escape;

            int count = Menu.Count;
            int cursor = 0;
            int positionStartY = 3;

            while (butNumber != ConsoleKey.Enter && butNumber != ConsoleKey.Escape) //Console.ReadKey().Key != ConsoleKey.Enter
            {
                Console.WriteLine();
                Console.WriteLine($"{message}");
                Console.WriteLine();

                for (int i = positionStartY; i < positionStartY + count; i++)
                {
                    if (cursor == i - positionStartY)
                    {
                        Console.BackgroundColor = (ConsoleColor)12;
                        Console.WriteLine(Menu[i - positionStartY]);
                        Console.BackgroundColor = (ConsoleColor)0;
                    }
                    else
                    {
                        Console.WriteLine(Menu[i - positionStartY]);
                    }
                }

                
                butNumber = Console.ReadKey().Key;

                if (butNumber == keyU)
                {
                    cursor--;
                }

                if (butNumber == keyD)
                {
                    cursor++;
                }


                if (cursor < 0)
                {
                    cursor = 0;
                }
                if (cursor >= count)
                {
                    cursor = count - 1;
                }

                Console.Clear();

            }

            if (butNumber== keyEnt)
            {
                listMenu++;
            }

            if (butNumber == keyEsc)
            {
                listMenu--;
            }

            butNumber = 0;

            return listMenu;
        }
    }
}
