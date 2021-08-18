using MySushiProject.UI.Enum;
using MySushiProject.Users;
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
        public static EnumListWindows UiMenus(List<User> Menu , string message, EnumListWindows listMenu)    //, out int posMenu)
        {
            ConsoleKey butNumber=0;
            var keyMin = ConsoleKey.Subtract;
            var keyPlus = ConsoleKey.Add;
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
                        Console.WriteLine(Menu[i - positionStartY].ToString());
                        Console.BackgroundColor = (ConsoleColor)0;
                    }
                    else
                    {
                        Console.WriteLine(Menu[i - positionStartY].ToString());
                    }
                }

                
                butNumber = Console.ReadKey().Key;

                if (butNumber == keyU)
                {
                    cursor--;
                    if (cursor < 0)
                    {
                        cursor = 0;
                    }
                }

                if (butNumber == keyD)
                {
                    cursor++;
                    if (cursor >= count)
                    {
                        cursor = count - 1;
                    }
                }

                if (butNumber == keyPlus)////
                {
                    Menu[cursor].Id++;
                    if (Menu[cursor].Id>10)
                    {
                        Menu[cursor].Id = 10;
                    }
                }

                if (butNumber == keyMin)////
                {
                    Menu[cursor].Id--;
                    if (Menu[cursor].Id < 0)
                    {
                        Menu[cursor].Id = 0;
                    }
                }



                Console.Clear();

            }

            //posMenu = cursor;

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
