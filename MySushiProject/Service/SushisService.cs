using MySushiProject.BL;
using MySushiProject.Events;
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
using System.Text;
using System.Threading.Tasks;

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

            int count = 0;


            while (true)
            {

                switch (listMenuWindows)
                {
                    case EnumListWindows.Start:
                        newUser = new User();

                        mes1 = $"Здравствуйте!";
                        mes2 = $"Как Вас Зовут?";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);

                        //********************************

                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Name = tempStr;
                        //*********************************************




                        //newUser.Name =  newUser.Name.PrintTextCenter(16);

                        if (string.IsNullOrWhiteSpace(newUser.Name))
                        {
                            errMesUi = "Поле Имя не должно быть пустым";
                        }
                        else { errMesUi = valid.CheckProperty(newUser.Name); }

                        if (errMesUi != null)
                        {
                            Log.logger.Itfo($"Не корректный ввод имени пользователя: \n\t\t{errMesUi}");

                            isValid = false;
                        }
                        else
                        {
                           

                            isValid = true;
                            listMenuWindows++;
                            errMesUi = null;
                            count++;
                            //break;
                        }



                        break;

                    case EnumListWindows.OrderOrMenu:
                        Console.Clear();
                       
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

                         mes1 = $"{newUser.Name},";
                         mes2 = $"введите Ваш номер телефона";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);

                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Phone = tempStr;

                        //newUser.Phone = newUser.Phone.PrintTextCenter(16);
                        if (string.IsNullOrWhiteSpace(newUser.Phone))
                        {
                            errMesUi = "Поле Телефон не должно быть пустым";
                        }
                        else { errMesUi = valid.CheckProperty(newUser); }

                        //errMesUi = valid.CheckProperty(newUser);
                        if (errMesUi == null)
                        {
                            isValid = true;
                            listMenuWindows++;
                            errMesUi = null;
                            break;
                        }
                        Log.logger.Itfo($"Не корректный ввод телефона пользователя: \n\t\t{errMesUi}");

                        isValid = false;

                        break;

                    case EnumListWindows.EnterEmail:
                        Console.Clear();

                        mes1 = $"{newUser.Name},";
                        mes2 = $"введите Ваш Email адрес";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);

                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Email = tempStr;

                        //newUser = UIEnterData.StartWindow(newUser, isValid, errMesUi);
                        //newUser.Email = newUser.Email.PrintTextCenter(16);

                        if (string.IsNullOrWhiteSpace(newUser.Email))
                        {
                            errMesUi = "Поле Email адрес не должно быть пустым";
                        }
                        else { errMesUi = valid.CheckProperty(newUser); }

                        //errMesUi = valid.CheckProperty(newUser);
                        if (errMesUi == null)
                        {
                            isValid = true;
                            listMenuWindows++;
                            errMesUi = null;
                            break;
                        }
                        Log.logger.Itfo($"Не корректный ввод Email адреса пользователя: \n\t\t{errMesUi}");

                        isValid = false;
                        break;

                    case EnumListWindows.EnterAddress:
                        Console.Clear();

                        mes1 = $"{newUser.Name},";
                        mes2 = $"введите Ваш адрес для доставки";

                        UIEnterData.PaintWindow(isValid, errMesUi, mes1, mes2);

                        listMenuWindows = UIEnterData.UIChekBut(listMenuWindows, out tempStr);
                        newUser.Address = tempStr;

                        //newUser = UIEnterData.StartWindow(newUser, isValid, errMesUi);
                        //newUser.Address = newUser.Address.PrintTextCenter(16);

                        if (string.IsNullOrWhiteSpace(newUser.Address))
                        {
                            errMesUi = "Поле Адрес доставки не должно быть пустым";
                        }
                        else { errMesUi = valid.CheckProperty(newUser); }

                        //errMesUi = valid.CheckProperty(newUser);
                        if (errMesUi == null)
                        {
                            isValid = true;
                            listMenuWindows++;
                            errMesUi = null;
                            break;
                        }
                        Log.logger.Itfo($"Не корректный ввод адреса доставки пользователя: \n\t\t{errMesUi}");

                        isValid = false;
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
                        newOrder.TotalCoast = SushiRepository.TotalCoast(newOrder.BasketOrders);
                        newOrder.Date = DateTime.Now;


                        break;

                    case EnumListWindows.End:

                        usersRepository.Add(newUser);
                        //////////////////////////////////newUser = new User();//
                        //Add user in repo
                        orderRepository.Add(newOrder);
                       
                        /////////////////////////////////newOrder = new Order();//
                        //Add Order in repo

                        //Basket = default;

                        "Спасибо за заказ!".WriteTextCenter(5);
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

        //private static EnumListWindows UIChekBut(EnumListWindows listMenuWindows, User newUser)
        //{
        //    //enterStr = null;
        //    char symb = default;

        //    do
        //    {
        //        symb = Console.ReadKey().KeyChar;

        //        if (!char.IsControl(symb))
        //        {


        //            newUser.Name = newUser.Name + symb;
        //        }
        //        //numdStr = 16;

        //        if (symb.Equals('\b'))
        //        {
        //            if (newUser.Name != null)
        //            {
        //                if (newUser.Name.Length > 0)
        //                {
        //                    newUser.Name = newUser.Name.Remove(newUser.Name.Length - 1);

        //                    //numdStr = 16;
        //                    StringExtensions.WriteTextCenter("                                  ", 16);

        //                }

        //            }

        //        }

        //        if (symb.Equals('\u001b'))
        //        {
        //            listMenuWindows--;
        //            break;
        //        }

        //        StringExtensions.WriteTextCenter(newUser.Name, 16);

        //    } while (!symb.Equals('\r'));
        //    return listMenuWindows;
        //}

    }
}
