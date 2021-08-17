using MySushiProject.UI;
using System;
using System.Collections.Generic;

namespace MySushiProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<string> Menu = new List<string>()
            {
                "Аризона",
                "Атами",
                "Сакура",
                "Филадельфия",
                "Мияги",
                "Токио"
            };

            List<string> Menu2 = new List<string>()
            {
                "Филадельфия",
                "Мияги",
                "Токио"
            };

            Console.WriteLine("Здравствуйте");
            Console.WriteLine("Как Вас зовут?");
            string name = " Console.ReadLine(); ";

            Console.Clear();


            List<string> Menu3 = new List<string>()
            {
                "Сделать заказ",
                "Посмотреть меню"
            };

            string message;

            int count = 0;


            switch (count)
            {
                case 0:
                    message = ($"{name}, хотите сделать заказ или посмотреть меню на сегодня?");
                    UIMenu.UiMenu(Menu3, message);
                    break;

                case 1:
                    message = $"{name}, Вы можете сделать заказ из меню на сегодня:";
                    UIMenu.UiMenu(Menu, message);
                    break;

                case 2:
                    message = $"{name}, Вы можете сделать заказ из меню2 на сегодня:";
                    UIMenu.UiMenu(Menu2, message);
                    break;

                default:
                    break;
            }

            //message=($"{name}, хотите сделать заказ или посмотреть меню на сегодня?");
            //UIMenu.UiMenu(Menu3, message);

            //message = $"{name}, Вы можете сделать заказ из меню на сегодня:";
            //UIMenu.UiMenu(Menu, message);

            //message = $"{name}, Вы можете сделать заказ из меню2 на сегодня:";
            //UIMenu.UiMenu(Menu2, message);

        }

        
    }
}

