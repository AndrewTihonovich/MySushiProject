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
        public static EnumListWindows UiMenus(List<BasketOrder> Basket, string mes1, string mes2, EnumListWindows listMenu)    //, out int posMenu)
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
                WriteDataFromList(Basket, mes1, mes2, cursor);

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
                    "****** Информация о продукте ******".WriteTextCenter(2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    var descripLine = Basket[cursor].Description.Split('\n');

                    for (int i = 0; i < descripLine.Length; i++)
                    {
                        Console.WriteLine($"\t{descripLine[i]}");
                    }
                       
                    "Нажмите любую клавишу чтобы вернуться".WriteTextCenter(Console.GetCursorPosition().Top+1);
                    Console.ReadKey();
                }

                if (butNumber == keyF1)////
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("\tДля передвижения вверх, вниз используйте стреки вверх, вниз\n" +
                                      "\tДля добавления/удаления в корзину используйте +/- \n" +
                                      "\tДля подтвержения нажмите Enter\n" +
                                      "\tДля вызова справки нажмите F1 \n" +
                                      "\tДля просмотра описания нажмите i\n "); ;

                    "Нажмите любую клавишу чтобы вернуться".WriteTextCenter(Console.GetCursorPosition().Top + 2);
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

        private static void WriteDataFromList(List<BasketOrder> Basket, string mes1, string mes2, int cursor)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            $"{mes1}".WriteTextCenter(1);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"\n\n{mes2}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\tНазвание\t\t   Количество\t    Цена порции\t    Стоимость\t    Описание\n");
            Console.ForegroundColor = ConsoleColor.White;

            int X = Console.GetCursorPosition().Left;
            int Y = Console.GetCursorPosition().Top;
            for (int i = 0; i < Basket.Count; i++)
            {
                if (cursor == i)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    PrintBasketOrder(Basket, X, Y, i);
                    //Console.WriteLine(Basket[i].ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    PrintBasketOrder(Basket, X, Y, i);

                    //Console.WriteLine(Basket[i].ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\tИтоговая стоимость заказа \t...\t...\t...\t...\t{SushiRepository.TotalCoastOrder(Basket)} ");
            Console.ForegroundColor = ConsoleColor.White;

            "Для справки нажмете F1".WriteTextCenter(Console.GetCursorPosition().Top+2);
        }

        private static void PrintBasketOrder(List<BasketOrder> Basket, int X, int Y, int i)
        {
            
            Console.SetCursorPosition(X + 8, Y + i);
            Console.Write($"{Basket[i].Name}                            ");

            Console.SetCursorPosition(X + 40, Y + i);
            Console.Write($"{Basket[i].AmountInOrder}                     ");

            Console.SetCursorPosition(X + 56, Y + i);
            Console.Write($"{Basket[i].Coast}                     ");

            Console.SetCursorPosition(X + 72, Y + i);
            Console.Write($"{Basket[i].CoastUnit = Math.Round(Basket[i].AmountInOrder * Basket[i].Coast, 2)}                ");

            Console.SetCursorPosition(X + 88, Y + i);
            Console.Write("i    ");
        }
    }
}
