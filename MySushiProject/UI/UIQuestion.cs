using MySushiProject.Extensions;
using System;
using System.Collections.Generic;

namespace MySushiProject.UI.Enum
{
    class UIQuestion
    {
        public static EnumListWindows UIQuestions(List<string> MenuButton, string message, EnumListWindows listMenu) 
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

            while (butNumber != ConsoleKey.Enter && butNumber != ConsoleKey.Escape)
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

                if (butNumber == keyF1)//???
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Для передвижения вверх, вниз используйте стреки вверх, вниз\n" +
                                      "Для добавления/удаления в корзину используйте +/- \n" +
                                      "Для подтвержения нажмите Enter\n" +
                                      "Для вызова справки нажмите F1 \n" +
                                      "Для просмотра описания нажмите i\n "); ;
                    Console.WriteLine();
                    Console.WriteLine("\n\n Нажмите любую клавишу чтобы вернуться");
                    Console.ReadKey();
                }

                Console.Clear();
            }

            if (butNumber == keyEnt)
            {
                if (cursor==0)
                {
                    listMenu++;
                }else
                 {
                    listMenu--;
                 }
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
            int numbLine = 4;
            message.WriteTextCenter(numbLine);
            
            for (int i = 0; i < MenuButton.Count; i++)
            {
                if (cursor == i)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    MenuButton[i].ToString().WriteTextCenter(numbLine + 4 + i);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    MenuButton[i].ToString().WriteTextCenter(numbLine + 4 + i);
                }
            }
        }
    }
}

