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
            var keyU = ConsoleKey.UpArrow;
            var keyD = ConsoleKey.DownArrow;
            var keyEnt = ConsoleKey.Enter;
            var keyEsc = ConsoleKey.Escape;
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
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("\tДля передвижения вверх, вниз используйте стреки вверх, вниз\n" +
                                      "\tДля добавления/удаления в корзину используйте +/- \n" +
                                      "\tДля подтвержения нажмите Enter\n" +
                                      "\tДля вызова справки нажмите F1 \n" +
                                      "\tДля просмотра описания нажмите i\n "); ;
                    
                    "Нажмите любую клавишу чтобы вернуться".WriteTextCenter(Console.GetCursorPosition().Top + 2);
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

