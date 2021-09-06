using MySushiProject.Models;
using MySushiProject.Extensions;
using MySushiProject.Repository;
using MySushiProject.UI.Enum;
using System;
using System.Collections.Generic;

namespace MySushiProject.UI
{
    class UIMenu
    {

        public static EnumListWindows UiMenus(List<BasketOrder> Basket, string message, EnumListWindows listMenu)    //, out int posMenu)
        {
            Console.CursorVisible = false;
            ConsoleKey butNumber=0;
            var keyMin = ConsoleKey.Subtract;
            var keyPlus = ConsoleKey.Add;
            var keyU = ConsoleKey.UpArrow;
            var keyD = ConsoleKey.DownArrow;
            var keyEnt = ConsoleKey.Enter;
            var keyEsc = ConsoleKey.Escape;
            var keyInfo = ConsoleKey.I;
            var keyF1 = ConsoleKey.F1;

            int count = Basket.Count;
            int cursor = 0;

            while (butNumber != ConsoleKey.Enter && butNumber != ConsoleKey.Escape) 
            {
                WriteDataFromList(Basket, message, cursor);

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

                if (butNumber == keyPlus)
                {
                    Basket[cursor].AmountInOrder++;
                    if (Basket[cursor].AmountInOrder > 10)
                    {
                        Basket[cursor].AmountInOrder = 10;
                    }
                }

                if (butNumber == keyMin)////try
                {
                    Basket[cursor].AmountInOrder--;
                    if (Basket[cursor].AmountInOrder < 0)
                    {
                        Basket[cursor].AmountInOrder = 0;
                    }
                }

                if (butNumber == keyInfo)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t****** Информация о продукте ******");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    try
                    {
                        Console.WriteLine(Basket[cursor].Description);
                    }
                    catch (Exception)
                    {

                    }
                    Console.WriteLine("\n\n Нажмите любую клавишу чтобы вернуться");
                    Console.ReadKey();
                }

                if (butNumber == keyF1)////
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\tДля передвижения вверх, вниз используйте стреки вверх, вниз\n" +
                                      "\tДля добавления/удаления в корзину используйте +/- \n" +
                                      "\tДля подтвержения нажмите Enter\n" +
                                      "\tДля вызова справки нажмите F1 \n" +
                                      "\tДля просмотра описания нажмите i\n "); ;

                    Console.WriteLine("\n\n\tНажмите любую клавишу чтобы вернуться");
                    Console.ReadKey();
                }

                if (butNumber == keyEnt)
                {
                    if (SushiRepository.TotalCoastOrder(Basket) != 0)
                    {
                        listMenu++;
                    }
                }

                if (butNumber == keyEsc)
                {
                    listMenu--;
                }

                Console.Clear();
            }

            butNumber = 0;

            return listMenu;
        }

        private static void WriteDataFromList(List<BasketOrder> Basket, string message, int cursor)
        {
            Console.WriteLine($"\n{message}");
            
            for (int i = 0; i < Basket.Count; i++)
            {
                if (cursor == i)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(Basket[i].ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine(Basket[i].ToString());
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\tИтоговая стоимость заказа \t...\t...\t...\t...\t{SushiRepository.TotalCoastOrder(Basket)} ");
            Console.ForegroundColor = ConsoleColor.White;

            "Для справки нажмете F1".WriteTextCenter(Console.GetCursorPosition().Top+1);
        }
    }
}
