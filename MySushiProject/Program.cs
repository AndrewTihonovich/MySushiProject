using MySushiProject.UI;
using System;
using System.Collections.Generic;

namespace MySushiProject
{
    class Program
    {
        static bool isEnter = false;
        static void Main(string[] args)
        {
            List<string> Menu = new List<string>()
            {
                "Аризона",
                "Атами",
                "Сакура",
                "Филадельфия",
                "Мияги",
                "Токио",
            };

            Console.WriteLine("Здравствуйте");
            Console.WriteLine("Как Вас зовут?");
            string name = " Console.ReadLine(); ";

            Console.Clear();
            Console.WriteLine($"{name}, Вы можете сделать заказ из меню на сегодня:");



            (int X, int Y) positionStart = Console.GetCursorPosition();
            foreach (var item in Menu)
            {
                Console.WriteLine(item);
            }
            (int X, int Y) positionStop = Console.GetCursorPosition();

            Console.Clear();
            Console.WriteLine($"{name}, Вы можете сделать заказ из меню на сегодня:");



            string message = $"{name}, Вы можете сделать заказ из меню на сегодня:";
            int count = Menu.Count;
            int cursor = 0;
            
            while (!isEnter) //Console.ReadKey().Key != ConsoleKey.Enter
            {
                for (int i = positionStart.Y; i < positionStop.Y; i++)
                {
                        if (cursor == i- positionStart.Y)
                        {
                            Console.BackgroundColor = (ConsoleColor)12;
                            Console.WriteLine(Menu[i - positionStart.Y]);
                            Console.BackgroundColor = (ConsoleColor)0;
                        }
                        else
                        {
                            Console.WriteLine(Menu[i - positionStart.Y]);
                        }
                }

                cursor = ChekButtons.CheckBut(cursor, out isEnter);

                Console.Clear();
                Console.WriteLine($"{message}");
            }


            






        }





    }
}

