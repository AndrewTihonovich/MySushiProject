using MySushiProject.Extensions;
using MySushiProject.Logger;
using MySushiProject.UI.Enum;
using MySushiProject.Users;
using MySushiProject.Validation;
using System;

namespace MySushiProject.UI
{
    class UIEnterData
    {
        const string str1 = "****************************************";
        const string str2 = "***                                  ***";
        const string str3 = "****************************************";
        


        public static void PaintWindow( bool isValid, string errMes, string mes1, string mes2)
        {
            
            //Log.logger.Debug($"Открыто окно StartWindow");
            int numdStr = 0;
            Console.Clear();
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;

            //string mes1 = "Здравствуйте!";
            numdStr = 10;
            mes1.WriteTextCenter(numdStr);

            //string mes2 = "Как Вас зовут?";
            numdStr = 12;
            mes2.WriteTextCenter(numdStr);
             
            PaintWindowError(isValid, errMes);

            Console.SetCursorPosition(width / 2, 16);
            Console.CursorVisible = true;

            //*********************************************
            //user.Name = Console.ReadLine();
            //*********************************************



            //user.Name = user.Name.PrintTextCenter(16);

            //*********************************************
            //string enterStr = null;
            //char symb = default; 
            //char preSymb=default;

            //do
            //{
            //    symb = Console.ReadKey().KeyChar;

            //    if (symb.Equals('\b'))
            //    {
            //        if (enterStr != null)
            //        {
            //            if (enterStr.Length>0)
            //            {
            //                preSymb = enterStr[enterStr.Length - 1];
            //                enterStr = enterStr.TrimEnd(preSymb);

            //                numdStr = 16;
            //                PrintTextCenter(str2, numdStr);

            //            }

            //        }

            //    }
            //    else
            //    { enterStr = enterStr + symb; }

            //    numdStr = 16;

            //    PrintTextCenter(enterStr, numdStr);

            //} while (!symb.Equals('\r'));

            //user.Name = enterStr;

            //******************************************************




            //Console.CursorVisible = false;

            //return user;
        }

        private static void PaintWindowError(bool isValid, string errMes)
        {
            int width = Console.WindowWidth;
            int numdStr;

            if (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else { Console.ForegroundColor = ConsoleColor.White; }

            numdStr = 15;
            str1.WriteTextCenter(numdStr);
            numdStr = 16;
            str2.WriteTextCenter(numdStr);
            numdStr = 17;
            str3.WriteTextCenter(numdStr);


            if (!isValid)
            {
                numdStr = 19;
                errMes.WriteTextCenter(numdStr);

                Console.ForegroundColor = ConsoleColor.White;
            }

            
        }

        public static EnumListWindows UIChekBut(EnumListWindows listMenuWindows, out string newUser)
        {
            //enterStr = null;
            CheckValidation valid = new CheckValidation();
            newUser = default;
            char symb = default;

            do
            {
                symb = Console.ReadKey().KeyChar;

                if (!char.IsControl(symb))
                {

                    if (newUser?.Length > str2.Trim('*').Length-1)
                    {
                        PaintWindowError(false, $"Длинна поля не может быть больше {str2.Trim('*').Length} символов");
                    }
                    else { newUser = newUser + symb; }
                }
                //numdStr = 16;

                if (symb.Equals('\b'))
                {
                    if (newUser != null)
                    {
                        if (newUser.Length > 0)
                        {
                            newUser = newUser.Remove(newUser.Length - 1);

                            //numdStr = 16;
                            str2.Trim('*').WriteTextCenter(16);

                        }

                    }

                }

                if (symb.Equals('\u001b'))
                {
                    listMenuWindows--;
                    newUser = null;
                    break;
                }

                newUser.WriteTextCenter(16);

            } while (!symb.Equals('\r'));


            //   ********************** Validate **********************
            //if (string.IsNullOrWhiteSpace(newUser))
            //{
            //    errMesUi = "Поле не может быть пустым";
            //}
            //else
            //{ errMesUi = valid.CheckObject(user); }

            //if (errMesUi != null)
            //{
            //    Log.logger.Itfo($"Не корректный ввод: \n\t\t{errMesUi}");

            //    isValid = false;
            //}
            //else
            //{
            //    isValid = true;
            //    listMenuWindows++;
            //    errMesUi = null;
            //    //break;
            //}
            //   ********************** Validate **********************




            //if (valid.isValidate(user, newUser, out errMesUi))
            //{
            //    isValid = true;
            //    listMenuWindows++;
            //    errMesUi = null;
            //}
            //else { isValid = false; }


            return listMenuWindows;
        }





        //private static void PrintTextCenter(string mes, int numdStr)
        //{
        //    int tempLength = 0;
        //    int width = Console.WindowWidth;
        //    if (mes != null)
        //    {
        //        tempLength = mes.Length;
        //    }

        //    int left = width / 2 - tempLength / 2;

        //    Console.SetCursorPosition(left, numdStr);
        //    Console.Write(mes);
        //    if (mes != null)
        //    {
        //        Console.SetCursorPosition(left + mes.Length - 1, numdStr);
        //    }
        //}
    }
}
