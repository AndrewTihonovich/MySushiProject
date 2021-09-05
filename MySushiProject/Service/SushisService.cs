using MySushiProject.Models;
using MySushiProject.Extensions;
using MySushiProject.Logger;
using MySushiProject.Repository;
using MySushiProject.UI;
using MySushiProject.UI.Enum;
using MySushiProject.Users;
using MySushiProject.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using MySushiProject.Sender;
using System.Text;

namespace MySushiProject.Service
{
    class SushisService
    {

        internal static void SushiServiceStart()
        {
            Log.logger.Itfo("Запущен сервис SushiService");
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

            CheckValidation valid = new CheckValidation();

            bool isValid = true;
            string errMesUi = null;
            string mes1= default;
            string mes2=default;
            string tempStr = default;

            //listMenuWindows = EnumListWindows.EnterPhone;

            bool test = false;
             
            


            while (true)
            {
                switch (listMenuWindows)
                {
                    case EnumListWindows.Start:
                        newUser = new User();
                        Console.Clear();

                        mes1 = $"Здравствуйте!";
                        mes2 = $"Как Вас Зовут?";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);
                        tempStr = newUser.Name;
                        //listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, newUser, out tempStr, out isValid, out errMesUi);
                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Name = tempStr;

                        //   ********************** Validate **********************
                        if (valid.isValidate(newUser, tempStr, out errMesUi, out isValid))
                        {
                            listMenuWindows++;
                        }
                        //   ********************** Validate **********************

                        break;

                    case EnumListWindows.OrderOrMenu:
                        Console.Clear();
                        Console.CursorVisible = false;

                        List<string> ls = new List<string>() { "Да", "Нет" };

                        listMenuWindows = UIQuestion.UIQuestions(ls, $"{newUser.Name}, хотите посмотреть меню на сегодня?", listMenuWindows);

                        break;

                    case EnumListWindows.MenuToday:
                        Console.Clear();
                        Console.CursorVisible = false;
                        message = $"\t{newUser.Name}, Вы можете сделать заказ из меню на сегодня:" +
                            $"\n\n" +
                            $"\tНазвание\t\t   Количество\t    Цена порции\t    Стоимость\t    Описание\n";
                       
                        Basket = new SushiRepository().GetAll();
                       
                        listMenuWindows = UIMenu.UiMenus(Basket, message, listMenuWindows);
                        //listMenuWindows = EnumListWindows.CheckOrder;
                        break;

                    case EnumListWindows.EnterPhone:
                        Console.Clear();
                        Console.CursorVisible = true;

                        mes1 = $"{newUser.Name},";
                        mes2 = $"введите Ваш номер телефона";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);

                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        //listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Phone = tempStr;

                        //   ********************** Validate **********************
                        if (valid.isValidate(newUser, newUser.Phone, out errMesUi, out isValid))
                        {
                            listMenuWindows++;
                        }
                        //   ********************** Validate **********************

                        break;

                    case EnumListWindows.EnterEmail:
                        Console.Clear();
                        Console.CursorVisible = true;

                        mes1 = $"{newUser.Name},";
                        mes2 = $"введите Ваш Email адрес";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);
                        
                        //listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, newUser, out tempStr, out errMesUi, out isValid);
                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Email = tempStr;

                        //   ********************** Validate **********************
                        if (valid.isValidate(newUser, newUser.Email, out errMesUi, out isValid))
                        {
                            listMenuWindows++;
                        }
                        //   ********************** Validate **********************

                        break;

                    case EnumListWindows.EnterAddress:
                        Console.Clear();
                        Console.CursorVisible = true;


                        mes1 = $"{newUser.Name},";
                        mes2 = $"введите Ваш адрес для доставки";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);

                        //listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, newUser, out tempStr, out errMesUi, out isValid);
                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Address = tempStr;

                        //   ********************** Validate **********************
                        if (valid.isValidate(newUser, newUser.Address, out errMesUi, out isValid))
                        {
                            listMenuWindows++;
                        }
                        //   ********************** Validate **********************
                        break;
                        
                    case EnumListWindows.CheckOrder:
                        Console.Clear();


                        ///////////////////////////////
                        newOrder = new Order();
                        ////////////////////////////
                        newOrder.BasketOrders = Basket.Where(x => x.AmountInOrder != 0).ToList();


                        message = $"\t {newUser.Name}, проверте Ваш заказ. Все верно?" +
                            $"\n\n" +
                            $"\tЗаказчик: {newUser.Name}\n" +
                            $"\tТелефон: {newUser.Phone}\n" +
                            $"\tАдрес доставки: {newUser.Address}\n\n" +
                            
                            $"\tНазвание\t\t   Количество\t    Цена порции\t    Стоимость\t\n";

                        listMenuWindows = UI.UIMenu.UiMenus(newOrder.BasketOrders, message, listMenuWindows);


                        newOrder.User = newUser;
                        newOrder.BasketOrders = newOrder.BasketOrders.Where(x => x.AmountInOrder != 0).ToList();
                        newOrder.TotalCoast = SushiRepository.TotalCoastOrder(newOrder.BasketOrders);
                        newOrder.Date = DateTime.Now;


                        break;

                    case EnumListWindows.End:
                        Console.CursorVisible = false;

                        usersRepository.Add(newUser);
                        //////////////////////////////////newUser = new User();//
                        //Add user in repo
                        
                        newOrder.OrderComplited += EmailSender.OrderComplited;
                        newOrder.OrderDelivered += EmailSender.OrderDelivered;
                        newOrder.OrderPaid += EmailSender.OrderPaid;
                        orderRepository.Add(newOrder);

                        /////////////////////////////////newOrder = new Order();//
                        //Add Order in repo

                        //Basket = default;


                        //string userRep = JsonConvert.SerializeObject(newUser);
                        //File.AppendAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\UserRep.txt", userRep);


                        //var text = JsonConvert.SerializeObject(newOrder, Formatting.Indented);
                        //File.AppendAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Orders.txt", text);




                        
                        //var convertedJson = JsonConvert.SerializeObject(orderRepository, Formatting.Indented);
                        //File.AppendAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Orders.json", convertedJson);







                        "Спасибо за заказ!".WriteTextCenter(5);
                        "Для продолжения нажмите любую клавишу".WriteTextCenter(35);
                        Console.ReadKey();
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


                //   ****************************    TEST   ****************************
                
                if (test)
                {
                    var orders = orderRepository.GetAll();

                    var order = orders[0];

                    order.isCompleted = true;
                    order.CheckCompleted(order);
                }
                //   ****************************    TEST   ****************************

            }
            //string userRep = JsonConvert.SerializeObject(newUser);
            //File.AppendAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\UserRep.txt", userRep);

            //string orderRep = JsonConvert.SerializeObject(newOrder);
            //File.AppendAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\OrderRep.txt", orderRep);

        }
    }
}
