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
using System.Threading.Tasks;
using System.Threading;

namespace MySushiProject.Service
{
    class SushisService
    {
        internal static void SushiServiceStart()
        {
            Log.logger.Info("Запущен сервис SushiService");
            EnumListWindows listMenuWindows = 0;

            SushiRepository sushiRepository = new SushiRepository();
            Log.logger.Info("Создан SushiRepository");

            UsersRepository usersRepository = new UsersRepository();
            Log.logger.Info("Создан UsersRepository");

            OrderRepository orderRepository = new OrderRepository();
            Log.logger.Info("Создан OrderRepository");

            User newUser = new User(Guid.NewGuid());
            
            List<BasketOrder> Basket = new List<BasketOrder>();
            Order newOrder = new Order(Guid.NewGuid());
            
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
                        Log.logger.Debug("Выбрано окно ввода имени");
                        newUser = new User(Guid.NewGuid());
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
                        Log.logger.Debug("Выбрано окно запроса меню");
                        Console.Clear();
                        Console.CursorVisible = false;

                        List<string> ls = new List<string>() { "Да", "Нет" };

                        listMenuWindows = UIQuestion.UIQuestions(ls, $"{newUser.Name}, хотите посмотреть меню на сегодня?", listMenuWindows);

                        break;

                    case EnumListWindows.MenuToday:
                        Log.logger.Debug("Выбрано окно вывода меню");
                        Console.Clear();
                        Console.CursorVisible = false;

                        mes1 = $"{newUser.Name}, Вы можете сделать заказ из меню на сегодня:";
                        mes2 = "";
                       
                        Basket = new SushiRepository().GetAll();  //sushiRepository.GetAll();

                        listMenuWindows = UIMenu.UiMenus(Basket, mes1, mes2, listMenuWindows);

                        break;

                    case EnumListWindows.EnterPhone:
                        Log.logger.Debug("Выбрано окно ввода телефона");
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
                        Log.logger.Debug("Выбрано окно ввода Email");
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
                        Log.logger.Debug("Выбрано окно ввода адреса");
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
                        Log.logger.Debug("Выбрано окно проверки заказа");
                        Console.Clear();

                        newOrder = new Order(Guid.NewGuid());
                        
                        newOrder.BasketOrders = Basket.Where(x => x.AmountInOrder != 0).ToList();

                        mes1 = $"{newUser.Name}, проверте Ваш заказ. Все верно?";
                                  
                        mes2 =  $"\tЗаказчик: {newUser.Name}\n" +
                                $"\tEmail: {newUser.Email}\n" +
                                $"\tТелефон: {newUser.Phone}\n" +
                                $"\tАдрес доставки: {newUser.Address}" +
                                $"\n";

                        listMenuWindows = UI.UIMenu.UiMenus(newOrder.BasketOrders, mes1, mes2, listMenuWindows);

                        break;

                    case EnumListWindows.End:
                        Log.logger.Debug("Выбрано окно завершения заказа");
                        Console.CursorVisible = false;

                        usersRepository.Add(newUser);
                        Log.logger.Info("Новый пользователь добавлен в UserRepository");

                        newOrder.User = newUser;
                        newOrder.BasketOrders = newOrder.BasketOrders.Where(x => x.AmountInOrder != 0).ToList();
                        newOrder.TotalCoast = SushiRepository.TotalCoastOrder(newOrder.BasketOrders);
                        newOrder.Date = DateTime.Now;
                        newOrder.OrderComplited += EmailSender.OrderComplited;
                        newOrder.OrderDelivered += EmailSender.OrderDelivered;
                        newOrder.OrderPaid += EmailSender.OrderPaid;
                        orderRepository.Add(newOrder);
                        Log.logger.Info("Новый заказ добавлен в OrderRepository");

                        "Спасибо за заказ! Ваш заказ принят!".WriteTextCenter(5);
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

                //   ****************************    TEST Events   ****************************
                if (test)
                {
                    var orders = orderRepository.GetAll();

                    var order = orders[1];

                    order.isCompleted = true;
                    order.CheckCompleted(order);

                    Thread.Sleep(10_000);
                    order.isDelivered = true;
                    order.CheckDelivered(order);

                    Thread.Sleep(10_000);
                    order.isPaid = true;
                    order.CheckPaid(order);
                    test = false;
                }
                //   ****************************    TEST Events  ****************************
            }
        }
    }
}
