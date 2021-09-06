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
using MySushiProject.Sender;

namespace MySushiProject.Service
{
    class SushisService
    {

        internal static void SushiServiceStart()
        {
            Log.logger.Itfo("Запущен сервис SushiService");
            string message;
            EnumListWindows listMenuWindows = 0;
            SushiRepository sushiRepository = new SushiRepository();
            Log.logger.Itfo("Create sushiRepository");
            UsersRepository usersRepository = new UsersRepository();
            Log.logger.Itfo("Create usersRepository");
            OrderRepository orderRepository = new OrderRepository();
            Log.logger.Itfo("Create orderRepository");
            User newUser = new User();
            Order newOrder = new Order();
            List<BasketOrder> Basket = new List<BasketOrder>();
            CheckValidation valid = new CheckValidation();

            bool isValid = true;
            string errMesUi = null;
            string mes1= default;
            string mes2=default;
            string tempStr = default;

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

                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Name = tempStr;

                        if (valid.isValidate(newUser, tempStr, out errMesUi, out isValid))
                        {
                            listMenuWindows++;
                        }

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

                        break;

                    case EnumListWindows.EnterPhone:
                        Console.Clear();
                        Console.CursorVisible = true;

                        mes1 = $"{newUser.Name},";
                        mes2 = $"введите Ваш номер телефона";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);

                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);

                        newUser.Phone = tempStr;

                        if (valid.isValidate(newUser, newUser.Phone, out errMesUi, out isValid))
                        {
                            listMenuWindows++;
                        }

                        break;

                    case EnumListWindows.EnterEmail:
                        Console.Clear();
                        Console.CursorVisible = true;

                        mes1 = $"{newUser.Name},";
                        mes2 = $"введите Ваш Email адрес";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);
                        
                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Email = tempStr;

                        if (valid.isValidate(newUser, newUser.Email, out errMesUi, out isValid))
                        {
                            listMenuWindows++;
                        }

                        break;

                    case EnumListWindows.EnterAddress:
                        Console.Clear();
                        Console.CursorVisible = true;

                        mes1 = $"{newUser.Name},";
                        mes2 = $"введите Ваш адрес для доставки";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);

                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Address = tempStr;

                        if (valid.isValidate(newUser, newUser.Address, out errMesUi, out isValid))
                        {
                            listMenuWindows++;
                        }
                        break;
                        
                    case EnumListWindows.CheckOrder:
                        Console.Clear();

                        newOrder = new Order();
                        
                        newOrder.BasketOrders = Basket.Where(x => x.AmountInOrder != 0).ToList();

                        message = $"\t {newUser.Name}, проверте Ваш заказ. Все верно?" +
                                  $"\n\n" +
                                  $"\tЗаказчик: {newUser.Name}\n" +
                                  $"\tEmail: {newUser.Email}\n" +
                                  $"\tТелефон: {newUser.Phone}\n" +
                                  $"\tАдрес доставки: {newUser.Address}" +
                                  $"\n\n" +
                                  $"\tНазвание\t\t   Количество\t    Цена порции\t    Стоимость\t\n";

                        listMenuWindows = UI.UIMenu.UiMenus(newOrder.BasketOrders, message, listMenuWindows);

                        break;

                    case EnumListWindows.End:
                        Console.CursorVisible = false;

                        usersRepository.Add(newUser);

                        newOrder.User = newUser;
                        newOrder.BasketOrders = newOrder.BasketOrders.Where(x => x.AmountInOrder != 0).ToList();
                        newOrder.TotalCoast = SushiRepository.TotalCoastOrder(newOrder.BasketOrders);
                        newOrder.Date = DateTime.Now;
                        newOrder.OrderComplited += EmailSender.OrderComplited;
                        newOrder.OrderDelivered += EmailSender.OrderDelivered;
                        newOrder.OrderPaid += EmailSender.OrderPaid;
                        orderRepository.Add(newOrder);

                        "Спасибо за заказ!".WriteTextCenter(5);
                        "Для продолжения нажмите любую клавишу".WriteTextCenter(35);
                        Console.ReadKey();

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
        }
    }
}
