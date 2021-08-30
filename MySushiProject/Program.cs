using MySushiProject.BL;
using MySushiProject.Extensions;
using MySushiProject.Logger;
using MySushiProject.Logger.Enum;
using MySushiProject.Service;
using MySushiProject.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MySushiProject
{
    class Program
    {

        
        static void Main(string[] args)
        {
            //    ******************   CreateLogger   ******************
            string path = @"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Logger\Logs\";
            Log.CreateLogger();
            Log.logger.LogConfig(path, 30000, MinLogLevel.Debug);
            //    ******************   CreateLogger   ******************

            
            //Console.SetWindowSize(Console.WindowWidth, 1000);

            //Console.CursorVisible = false;
            //var cw = Console.WindowWidth;
            //var ch = Console.WindowHeight;
            //*******************************************************
            Console.SetWindowSize(100, 40);
            Log.logger.Debug("Изменен размер консольного окна");
            //*******************************************************


            

            //    ******************   StartSushiService   ******************
            SushisService.SushiServiceStart();
            //    ******************   StartSushiService   ******************


            //Sushi su = new Sushi( 1, "ksd", 8, "kjslfjlf");

            //User u1 = new User();
            //u1.Name = "Name";
            //u1.Phone = "+354956265846";
            //u1.Email = "jdfhk@tu.vif";
            //Order o1 = new Order();
            //o1.User = u1;
            //o1.Date = DateTime.Now;

            //u1 = new User();


            //Sushi sushi = new Sushi( "jkdfhgdksj", 12, "description");
            //sushi.SushiListJSON();

            //List<User> Menu8 = new List<User>()
            //{

            //};
            //Menu8.Add(new User { Id = 1, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            //Menu8.Add(new User { Id = 2, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            //Menu8.Add(new User { Id = 3, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            //Menu8.Add(new User { Id = 4, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            //Menu8.Add(new User { Id = 5, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });
            //Menu8.Add(new User { Id = 6, Address = "jdgf", Email = "sdfligsd", Name = "jashk", Phone = "jkhdfgkdf" });

            //Sushi sushi = new Sushi(1, "kjhvgfg", 4, 15); //{ Amount = 4, Coast = 15, Name = "kdslkdgsd" };
            //Sushi sushi2 = new Sushi(2, "kjhvgfg", 5, 55);




            //List<string> Menu = new List<string>()
            //{
            //    "Аризона",
            //    "Атами",
            //    "Сакура",
            //    "Филадельфия",
            //    "Мияги",
            //    "Токио"
            //};

            //List<string> Menu2 = new List<string>()
            //{
            //    "Филадельфия",
            //    "Мияги",
            //    "Токио"
            //};

            //Console.WriteLine("Здравствуйте");
            //Console.WriteLine("Как Вас зовут?");


            //Console.Clear();


            //List<string> Menu3 = new List<string>()
            //{
            //    "Сделать заказ",
            //    "Посмотреть меню"
            //};



            //string message;
            //EnumListWindows listMenuWindows = 0;
            ////EnumListMenu listMenu2 = 0;
            //SushiRepository sushiRepository = new SushiRepository();
            //Log.logger.Itfo("Create sushiRepository");
            //UsersRepository usersRepository = new UsersRepository();
            //Log.logger.Itfo("Create usersRepository");
            //OrderRepository orderRepository = new OrderRepository();
            //Log.logger.Itfo("Create orderRepository");
            //User newUser = new User();
            //Order newOrder = new Order();

            ////List<BasketOrder> Menu = sushiRepository.GetAll();
            //List<BasketOrder> Basket = new List<BasketOrder>();


            //while (true)
            //{

            //  switch (listMenuWindows)
            //  {
            //        case EnumListWindows.Start:
            //            newUser = new User();
            //            StartWindow(newUser);
            //            //newUser.Name = name;
            //            if (!newUser.Name.Equals(null))
            //            {
            //                listMenuWindows++;
            //            }
            //            listMenuWindows++;
            //            break;

            //        case EnumListWindows.OrderOrMenu:
            //            Console.Clear();
            //            //Console.WriteLine($"{newUser.Name}, хотите посмотреть меню на сегодня?");
            //            //Console.ReadLine();

            //            List<string> ls = new List<string>() { "Да", "Нет" };

            //            listMenuWindows = UIQuestion.UIQuestions(ls, $"\n{newUser.Name}, хотите посмотреть меню на сегодня?\n", listMenuWindows);

            //            //listMenuWindows = UIMenu.UiMenus(Menu8, message, listMenuWindows);

            //            //listMenuWindows++;
            //            break;

            //    case EnumListWindows.MenuToday:
            //            Console.Clear();
            //            Console.CursorVisible = false;
            //            message = $"{newUser.Name}, Вы можете сделать заказ из меню на сегодня:" +
            //                $"\n\n\n\n" +
            //                $"\tНазвание\t\t   Количество\t    Цена порции\t    Стоимость\t    Описание\n";
            //            //ListSushi listSushi = new ListSushi();

            //            //Menu = sushiRepository.GetAll();
            //            //Basket = new List<BasketOrder>();
            //            Basket = new SushiRepository().GetAll();

            //            //*************************************
            //            //Sushi Menu = new BasketOrder("dsrhfg", 8, "kjdsfksdnjf");
            //            //BasketOrder Menu2 = new Sushi("dsrhfg", 8, "kjdsfksdnjf");

            //            //Menu.Add(new Sushi("dsrhfg", 8, "kjdsfksdnjf") );
            //            //for (int i = 0; i < Basket.Count; i++)
            //            //{
            //            //    Menu.Add(Basket[i]);
            //            //}
            //            //*************************************

            //            //var Menu = listSushi.SushiList();

            //            listMenuWindows = UIMenu.UiMenus(Basket, message, listMenuWindows);
            //            //listMenuWindows = EnumListWindows.CheckOrder;
            //            break;

            //    case EnumListWindows.EnterPhone:
            //            Console.Clear();
            //            Console.WriteLine($"{newUser.Name}, введите Ваш номер телефона");
            //            newUser.Phone=Console.ReadLine(); // validation!!!!!!
            //            listMenuWindows++;
            //            break;

            //    case EnumListWindows.EnterEmail:
            //            Console.Clear();
            //            Console.WriteLine($"{newUser.Name}, введите Ваш Email");
            //            newUser.Email=Console.ReadLine(); // validation!!!!!!
            //            listMenuWindows++;
            //            break;

            //    case EnumListWindows.EnterAddress:
            //            Console.Clear();
            //            Console.WriteLine($"{newUser.Name}, введите Ваш адрес для доставки");
            //            newUser.Address = Console.ReadLine(); // validation!!!!!!
            //            listMenuWindows++;
            //            break;

            //    case EnumListWindows.CheckOrder:
            //            Console.Clear();
            //            //Order newOrder = new Order();

            //            newOrder.BasketOrders = Basket.Where(x => x.AmountInOrder != 0).ToList();


            //            //Console.WriteLine($"{newUser.Name}, проверте Ваш заказ. \n");

            //            //Console.WriteLine("Название\t\t   Количество\t    Цена порции\t    Стоимость\t");
            //            message = $" {newUser.Name}, проверте Ваш заказ. Все верно?" +
            //                $"\n\n\n" +
            //                $"\tАдрес доставки: {newUser.Address}\n" +
            //                $"\tНазвание\t\t   Количество\t    Цена порции\t    Стоимость\t\n";
            //            listMenuWindows = UIMenu.UiMenus(newOrder.BasketOrders, message, listMenuWindows);

            //            //for (int i = 0; i < newOrder.BasketOrders.Count; i++)
            //            //{
            //            //    Console.WriteLine(newOrder.BasketOrders[i]);
            //            //    //"{Name}\t\t{AmountInOrder}\t\t{Coast
            //            //    }\t\t{CoastUnit = Math.Round(AmountInOrder * Coast, 2)}"
            //            //}

            //            newOrder.User = newUser;
            //            newOrder.BasketOrders = newOrder.BasketOrders.Where(x => x.AmountInOrder != 0).ToList();
            //            newOrder.TotalCoast = SushiRepository.TotalCoast(newOrder.BasketOrders);


            //            //Console.WriteLine($"Общая стоимость заказа {newOrder.TotalCoast}\n");

            //            //Console.WriteLine("Все верно?");
            //            //Console.ReadLine(); 

            //            //listMenuWindows++;
            //            break;

            //    case EnumListWindows.End:

            //            usersRepository.Add(newUser);
            //            newUser = new User();//
            //            //Add user in repo
            //            orderRepository.Add(newOrder);
            //            newOrder = new Order();//
            //            //Add Order in repo

            //            //Basket = default;

            //            Console.WriteLine("Спасибо за заказ!");
            //            Console.ReadLine();
            //            //Event Send to Email

            //            listMenuWindows = EnumListWindows.Start;
            //            break;

            //        default:
            //            if (listMenuWindows < 0)
            //            {
            //                listMenuWindows = 0;
            //            }

            //            if ((int)listMenuWindows >= Enum.GetNames(typeof(EnumListWindows)).Length)
            //            {
            //                listMenuWindows = (EnumListWindows)Enum.GetNames(typeof(EnumListWindows)).Length-1;
            //            }

            //            break;
            //  }


            //}

            //message=($"{name}, хотите сделать заказ или посмотреть меню на сегодня?");
            //UIMenu.UiMenu(Menu3, message);

            //message = $"{name}, Вы можете сделать заказ из меню на сегодня:";
            //UIMenu.UiMenu(Menu, message);

            //message = $"{name}, Вы можете сделать заказ из меню2 на сегодня:";
            //UIMenu.UiMenu(Menu2, message);

        }

        //private static void StartWindow(User newUser)
        //{
        //    Console.Clear();
        //    Console.SetCursorPosition(40, 10);
        //    Console.WriteLine("Здравствуйте");
        //    Console.SetCursorPosition(39, 12);
        //    Console.WriteLine("Как Вас зовут?");

        //    Console.SetCursorPosition(33, 15);
        //    Console.WriteLine("**************************");
        //    Console.SetCursorPosition(33, 16);
        //    Console.WriteLine("***                    ***");
        //    Console.SetCursorPosition(33, 17);
        //    Console.WriteLine("**************************");

        //    Console.SetCursorPosition(40, 16);
        //    Console.CursorVisible = true;
        //    newUser.Name = Console.ReadLine();

        //    Console.CursorVisible = false;

        //    Log.logger.Debug("StartWindow complite");
        //}

    }
}

