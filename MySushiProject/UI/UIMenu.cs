using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.UI
{
    class UIMenu
    {
        static bool isEnter = false;
        public static void UiMenu(List<string> Menu, string message)
        {
            int count = Menu.Count;
            int cursor = 0;
            int positionStartY = 3;

            while (!isEnter) //Console.ReadKey().Key != ConsoleKey.Enter
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

                cursor = ChekButtons.CheckBut(cursor, out isEnter);
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
            isEnter = false;
        }
    }
}
