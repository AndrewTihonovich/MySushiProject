using MySushiProject.BL;
using MySushiProject.Repository;
using MySushiProject.UI;
using MySushiProject.UI.Enum;
using MySushiProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MySushiProject
{
    class Program
    {

        
        static void Main(string[] args)
        {
            //Console.SetWindowSize(Console.WindowWidth, 1000);

            //Console.CursorVisible = false;
            //var cw = Console.WindowWidth;
            //var ch = Console.WindowHeight;
            Console.SetWindowSize(100, 30);

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



            string message;
            EnumListWindows listMenuWindows = 0;
            //EnumListMenu listMenu2 = 0;
            SushiRepository sushiRepository = new SushiRepository();
            UsersRepository usersRepository = new UsersRepository();
            OrderRepository orderRepository = new OrderRepository();
            User newUser = new User();
            Order newOrder = new Order();
            
            //List<BasketOrder> Menu = sushiRepository.GetAll();
            List<BasketOrder> Basket = new List<BasketOrder>();
            

            while (true)
            {
                
              switch (listMenuWindows)
              {
                case EnumListWindows.Start:
                        newUser = new User();
                        Console.Clear();
                        Console.WriteLine("Здравствуйте");
                        Console.WriteLine("Как Вас зовут?");
                        newUser.Name = Console.ReadLine();
                        //newUser.Name = name;
                        listMenuWindows++;
                    break;

                case EnumListWindows.OrderOrMenu:
                        Console.Clear();
                        Console.WriteLine($"{newUser.Name}, хотите посмотреть меню на сегодня?");
                        Console.ReadLine();
                        listMenuWindows++;
                        //listMenuWindows = UIMenu.UiMenus(Menu8, message, listMenuWindows);
                        break;

                case EnumListWindows.MenuToday:
                        Console.Clear();
                        Console.CursorVisible = false;
                        message = $"{newUser.Name}, Вы можете сделать заказ из меню на сегодня:";
                        //ListSushi listSushi = new ListSushi();

                        //Menu = sushiRepository.GetAll();
                        //Basket = new List<BasketOrder>();
                        Basket = new SushiRepository().GetAll();
                        
                        //var Menu = listSushi.SushiList();
                        
                        listMenuWindows = UIMenu.UiMenus(Basket, message, listMenuWindows);
                        listMenuWindows = EnumListWindows.CheckOrder;
                        break;

                case EnumListWindows.EnterPhone:
                        Console.Clear();
                        Console.WriteLine($"{newUser.Name}, введите Ваш номер телефона");
                        newUser.Phone=Console.ReadLine(); // validation!!!!!!
                        listMenuWindows++;
                        break;

                case EnumListWindows.EnterEmail:
                        Console.Clear();
                        Console.WriteLine($"{newUser.Name}, введите Ваш Email");
                        newUser.Email=Console.ReadLine(); // validation!!!!!!
                        listMenuWindows++;
                        break;

                case EnumListWindows.EnterAddress:
                        Console.Clear();
                        Console.WriteLine($"{newUser.Name}, введите Ваш адрес для доставки");
                        newUser.Address = Console.ReadLine(); // validation!!!!!!
                        listMenuWindows++;
                        break;

                case EnumListWindows.CheckOrder:
                        Console.Clear();
                        //Order newOrder = new Order();
                        newOrder.User = newUser;
                        newOrder.BasketOrders = Basket.Where(x => x.CoastUnit != 0).ToList();
                        newOrder.TotalCoast = SushiRepository.TotalCoast(newOrder.BasketOrders);

                        Console.WriteLine($"{newUser.Name}, проверте Ваш заказ. \n");

                        Console.WriteLine("Название\t\t   Количество\t    Цена порции\t    Стоимость\t");
                        for (int i = 0; i < newOrder.BasketOrders.Count; i++)
                        {
                            Console.WriteLine(newOrder.BasketOrders[i]);
                            //"{Name}\t\t{AmountInOrder}\t\t{Coast}\t\t{CoastUnit = Math.Round(AmountInOrder * Coast, 2)}"
                        }
                        Console.WriteLine($"Общая стоимость заказа {newOrder.TotalCoast}\n");

                        Console.WriteLine("Все верно?");
                        Console.ReadLine(); // validation!!!!!!

                        listMenuWindows++;
                        break;

                case EnumListWindows.End:

                        usersRepository.Add(newUser);
                        newUser = new User();//
                        //Add user in repo
                        orderRepository.Add(newOrder);
                        newOrder = new Order();//
                        //Add Order in repo

                        //Basket = default;

                        Console.WriteLine("Спасибо за заказ!");
                        Console.ReadLine();
                        //Event Send to Email

                        listMenuWindows = EnumListWindows.Start;
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

