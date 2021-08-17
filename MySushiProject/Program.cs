using MySushiProject.UI;
using MySushiProject.UI.Enum;
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

            EnumListMenu listMenu = 0;
            //EnumListMenu listMenu2 = 0;

            while (true)
            {
                
              switch (listMenu)
              {
                case EnumListMenu.Start:
                    message = ($"{name}, хотите сделать заказ или посмотреть меню на сегодня?");
                    listMenu=UIMenu.UiMenus(Menu3, message, listMenu);
                    break;

                case EnumListMenu.Order:
                    message = $"{name}, Вы можете сделать заказ из меню на сегодня:";
                    listMenu = UIMenu.UiMenus(Menu, message, listMenu);
                    break;

                case EnumListMenu.Order2:
                    message = $"{name}, Вы можете сделать заказ из меню2 на сегодня:";
                    listMenu = UIMenu.UiMenus(Menu2, message, listMenu);
                    break;

                default:
                        if (listMenu < 0)
                        {
                            listMenu = 0;
                        }

                        if ((int)listMenu >= Enum.GetNames(typeof(EnumListMenu)).Length)
                        {
                            listMenu = (EnumListMenu)Enum.GetNames(typeof(EnumListMenu)).Length-1;
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

