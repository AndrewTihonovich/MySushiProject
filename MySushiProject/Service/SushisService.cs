using MySushiProject.BL;
using MySushiProject.Logger;
using MySushiProject.Repository;
using MySushiProject.UI.Enum;
using MySushiProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Service
{
    class SushisService
    {
        internal static void SushiServiceStart()
        {
            string message;
            EnumListWindows listMenuWindows = 0;
            //EnumListMenu listMenu2 = 0;
            SushiRepository sushiRepository = new SushiRepository();
            Log.logger.Itfo("Create sushiRepository");
            UsersRepository usersRepository = new UsersRepository();
            Log.logger.Itfo("Create usersRepository");
            OrderRepository orderRepository = new OrderRepository();
            Log.logger.Itfo("Create orderRepository");
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
                        StartWindow(newUser);
                        //newUser.Name = name;
                        if (!string.IsNullOrWhiteSpace(newUser.Name))
                        {
                            listMenuWindows++;
                        }
                        else { }
                        //listMenuWindows++;
                        break;

                    case EnumListWindows.OrderOrMenu:
                        Console.Clear();
                        //Console.WriteLine($"{newUser.Name}, хотите посмотреть меню на сегодня?");
                        //Console.ReadLine();

                        List<string> ls = new List<string>() { "Да", "Нет" };

                        listMenuWindows = UIQuestion.UIQuestions(ls, $"\n{newUser.Name}, хотите посмотреть меню на сегодня?\n", listMenuWindows);

                        //listMenuWindows = UIMenu.UiMenus(Menu8, message, listMenuWindows);

                        //listMenuWindows++;
                        break;

                    case EnumListWindows.MenuToday:
                        Console.Clear();
                        Console.CursorVisible = false;
                        message = $"{newUser.Name}, Вы можете сделать заказ из меню на сегодня:" +
                            $"\n\n\n\n" +
                            $"\tНазвание\t\t   Количество\t    Цена порции\t    Стоимость\t    Описание\n";
                        //ListSushi listSushi = new ListSushi();

                        //Menu = sushiRepository.GetAll();
                        //Basket = new List<BasketOrder>();
                        Basket = new SushiRepository().GetAll();

                        //*************************************
                        //Sushi Menu = new BasketOrder("dsrhfg", 8, "kjdsfksdnjf");
                        //BasketOrder Menu2 = new Sushi("dsrhfg", 8, "kjdsfksdnjf");

                        //Menu.Add(new Sushi("dsrhfg", 8, "kjdsfksdnjf") );
                        //for (int i = 0; i < Basket.Count; i++)
                        //{
                        //    Menu.Add(Basket[i]);
                        //}
                        //*************************************

                        //var Menu = listSushi.SushiList();

                        listMenuWindows = UI.UIMenu.UiMenus(Basket, message, listMenuWindows);
                        //listMenuWindows = EnumListWindows.CheckOrder;
                        break;

                    case EnumListWindows.EnterPhone:
                        Console.Clear();
                        Console.WriteLine($"{newUser.Name}, введите Ваш номер телефона");
                        newUser.Phone = Console.ReadLine(); // validation!!!!!!
                        listMenuWindows++;
                        break;

                    case EnumListWindows.EnterEmail:
                        Console.Clear();
                        Console.WriteLine($"{newUser.Name}, введите Ваш Email");
                        newUser.Email = Console.ReadLine(); // validation!!!!!!
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

                        newOrder.BasketOrders = Basket.Where(x => x.AmountInOrder != 0).ToList();


                        //Console.WriteLine($"{newUser.Name}, проверте Ваш заказ. \n");

                        //Console.WriteLine("Название\t\t   Количество\t    Цена порции\t    Стоимость\t");
                        message = $" {newUser.Name}, проверте Ваш заказ. Все верно?" +
                            $"\n\n\n" +
                            $"\tАдрес доставки: {newUser.Address}\n" +
                            $"\tНазвание\t\t   Количество\t    Цена порции\t    Стоимость\t\n";
                        listMenuWindows = UI.UIMenu.UiMenus(newOrder.BasketOrders, message, listMenuWindows);

                        //for (int i = 0; i < newOrder.BasketOrders.Count; i++)
                        //{
                        //    Console.WriteLine(newOrder.BasketOrders[i]);
                        //    //"{Name}\t\t{AmountInOrder}\t\t{Coast
                        //    }\t\t{CoastUnit = Math.Round(AmountInOrder * Coast, 2)}"
                        //}

                        newOrder.User = newUser;
                        newOrder.BasketOrders = newOrder.BasketOrders.Where(x => x.AmountInOrder != 0).ToList();
                        newOrder.TotalCoast = SushiRepository.TotalCoast(newOrder.BasketOrders);


                        //Console.WriteLine($"Общая стоимость заказа {newOrder.TotalCoast}\n");

                        //Console.WriteLine("Все верно?");
                        //Console.ReadLine(); 

                        //listMenuWindows++;
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
                            listMenuWindows = (EnumListWindows)Enum.GetNames(typeof(EnumListWindows)).Length - 1;
                        }

                        break;
                }


            }

            
        }

        private static void StartWindow(User newUser)
        {
            Console.Clear();
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("Здравствуйте");
            Console.SetCursorPosition(39, 12);
            Console.WriteLine("Как Вас зовут?");

            Console.SetCursorPosition(33, 15);
            Console.WriteLine("**************************");
            Console.SetCursorPosition(33, 16);
            Console.WriteLine("***                    ***");
            Console.SetCursorPosition(33, 17);
            Console.WriteLine("**************************");

            Console.SetCursorPosition(40, 16);
            Console.CursorVisible = true;
            newUser.Name = Console.ReadLine();

            Console.CursorVisible = false;

            Log.logger.Debug("StartWindow complite");
        }
    }
}
