using MySushiProject.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.UI.Enum
{
    class UIQuestion
    {
        public static EnumListWindows UIQuestions(List<string> MenuButton, string message, EnumListWindows listMenu)    //, out int posMenu)
        {
            ConsoleKey butNumber = 0;
            var keyMin = ConsoleKey.Subtract;
            var keyPlus = ConsoleKey.Add;
            var keyU = ConsoleKey.UpArrow;
            var keyD = ConsoleKey.DownArrow;
            var keyEnt = ConsoleKey.Enter;
            var keyEsc = ConsoleKey.Escape;
            var keyInfo = ConsoleKey.I;
            var keyF1 = ConsoleKey.F1;

            int count = MenuButton.Count;
            int cursor = 0;

            while (butNumber != ConsoleKey.Enter && butNumber != ConsoleKey.Escape) //Console.ReadKey().Key != ConsoleKey.Enter
            {
                WriteDataFromList(MenuButton, message, cursor);

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

                //if (butNumber == keyPlus)////
                //{
                //    MenuButton[cursor].AmountInOrder++;
                //    if (MenuButton[cursor].AmountInOrder > 10)
                //    {
                //        MenuButton[cursor].AmountInOrder = 10;
                //    }
                //}

                //if (butNumber == keyMin)////
                //{
                //    MenuButton[cursor].AmountInOrder--;
                //    if (MenuButton[cursor].AmountInOrder < 0)
                //    {
                //        MenuButton[cursor].AmountInOrder = 0;
                //    }
                //}

                //if (butNumber == keyInfo)
                //{
                //    Console.Clear();
                //    Console.WriteLine("\n\t****** Информация о продукте ******");
                //    Console.WriteLine();
                //    try
                //    {
                //        Console.WriteLine(MenuButton[cursor].Description);
                //    }
                //    catch (Exception)
                //    {

                //    }
                //    Console.WriteLine("\n\n Нажмите любую клавишу чтобы вернуться");
                //    Console.ReadKey();
                //}

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
                    Console.WriteLine("\n\n Нажмите любую клавишу чтобы вернуться");
                    Console.ReadKey();
                }


                Console.Clear();

            }

            //posMenu = cursor;

            if (butNumber == keyEnt)
            {
                if (cursor==0)
                {
                    listMenu++;
                }else
                   {
                      listMenu--;
                   }
                
                //Order order = new Order() { TotalCoast= ListSushi.TotalCoast(Menu) };

            }

            if (butNumber == keyEsc)
            {
                listMenu--;
            }

            butNumber = 0;

            return listMenu;
        }

        private static void WriteDataFromList(List<string> MenuButton, string message, int cursor)
        {
            //Console.WriteLine();
            Console.WriteLine($"\n{message}");
            //Console.WriteLine();

            //Console.WriteLine("Название\t\t   Количество\t    Цена порции\t    Стоимость\t    Описание");

            for (int i = 0; i < MenuButton.Count; i++)
            {
                if (cursor == i)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(MenuButton[i].ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine(MenuButton[i].ToString());
                }
            }

            //Console.WriteLine();
            //Console.WriteLine($"Итоговая стоимость заказа {SushiRepository.TotalCoast(Basket)} ");
        }
    }
}

