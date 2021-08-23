using MySushiProject.BL;
using MySushiProject.Repository;
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
        public static EnumListWindows UiMenus(List<BasketOrder> Menu , string message, EnumListWindows listMenu)    //, out int posMenu)
        {
            ConsoleKey butNumber=0;
            var keyMin = ConsoleKey.Subtract;
            var keyPlus = ConsoleKey.Add;
            var keyU = ConsoleKey.UpArrow;
            var keyD = ConsoleKey.DownArrow;
            var keyEnt = ConsoleKey.Enter;
            var keyEsc = ConsoleKey.Escape;
            var keyInfo = ConsoleKey.I;
            var keyF1 = ConsoleKey.F1;

            int count = Menu.Count;
            int cursor = 0;
            int positionStartY = 4;

            while (butNumber != ConsoleKey.Enter && butNumber != ConsoleKey.Escape) //Console.ReadKey().Key != ConsoleKey.Enter
            {
                Console.WriteLine();
                Console.WriteLine($"{message}");
                Console.WriteLine();

                Console.WriteLine("Название\t\tКоличество\tЦена порции\tСтоимость\tОписание");

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

                Console.WriteLine();
                Console.WriteLine($"Итоговая стоимость заказа {SushiRepository.TotalCoast(Menu)} ");

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
                    Menu[cursor].AmountInOrder++;
                    if (Menu[cursor].AmountInOrder > 10)
                    {
                        Menu[cursor].AmountInOrder = 10;
                    }
                }

                if (butNumber == keyMin)////
                {
                    Menu[cursor].AmountInOrder--;
                    if (Menu[cursor].AmountInOrder < 0)
                    {
                        Menu[cursor].AmountInOrder = 0;
                    }
                }

                if (butNumber == keyInfo)
                {
                    Console.Clear();
                    Console.WriteLine("Description\n\n Нажмите любую клавишу чтобы вернуться");
                    Console.WriteLine();
                    try
                    {
                        Console.WriteLine(Menu[cursor].Description);
                    }
                    catch (Exception)
                    {

                    }
                    Console.ReadKey();
                }

                if (butNumber == keyF1)////
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Для передвижения вверх, вниз используйте стреки вверх, вниз\n" +
                        "Для добавления/удаления в корзину используйте +/- \n" +
                        "Для подтвержения нажмите Enter\n" +
                        "Для вызова справки нажмите F1 \n" +
                        "Для просмотра описания нажмите I\n "); ;
                    Console.WriteLine();
                    Console.WriteLine("Description\n\n Нажмите любую клавишу чтобы вернуться"); 
                    Console.ReadKey();
                }


                Console.Clear();

            }

            //posMenu = cursor;

            if (butNumber== keyEnt)
            {
                listMenu++;
                //Order order = new Order() { TotalCoast= ListSushi.TotalCoast(Menu) };

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
