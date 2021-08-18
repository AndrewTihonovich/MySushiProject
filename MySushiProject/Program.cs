using MySushiProject.BL;
using MySushiProject.UI;
using MySushiProject.UI.Enum;
using MySushiProject.Users;
using System;
using System.Collections.Generic;

namespace MySushiProject
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<User> Menu8 = new List<User>()
            {
              
            };
            Menu8.Add(new User { Id = 1, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            Menu8.Add(new User { Id = 2, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            Menu8.Add(new User { Id = 3, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            Menu8.Add(new User { Id = 4, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            Menu8.Add(new User { Id = 5, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            Menu8.Add(new User { Id = 6, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });

            Sushi sushi = new Sushi(1, "kjhvgfg", 4, 15); //{ Amount = 4, Coast = 15, Name = "kdslkdgsd" };
            Sushi sushi2 = new Sushi(2, "kjhvgfg", 5, 55);




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

            EnumListWindows listMenuWindows = 0;
            //EnumListMenu listMenu2 = 0;

            while (true)
            {
                
              switch (listMenuWindows)
              {
                case EnumListWindows.Start:
                    message = ($"{name}, хотите сделать заказ или посмотреть меню на сегодня?");
                    listMenuWindows=UIMenu.UiMenus(Menu8, message, listMenuWindows);
                    break;

                case EnumListWindows.OrderOrMenu:
                    message = $"{name}, Вы можете сделать заказ из меню на сегодня:";
                    listMenuWindows = UIMenu.UiMenus(Menu8, message, listMenuWindows);
                    break;

                case EnumListWindows.MenuToday:
                    message = $"{name}, Вы можете сделать заказ из меню2 на сегодня:";
                    listMenuWindows = UIMenu.UiMenus(Menu8, message, listMenuWindows);
                    break;

                default:
                        if (listMenuWindows < 0)
                        {
                            listMenuWindows = 0;
                        }

                        if ((int)listMenuWindows >= Enum.GetNames(typeof(EnumListWindows)).Length)
                        {
                            listMenuWindows = (EnumListWindows)Enum.GetNames(typeof(EnumListWindows)).Length-1;
                        }
                        
                        break;
              }

            
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

