﻿using MySushiProject.Extensions;
using MySushiProject.Logger;
using MySushiProject.Users;
using MySushiProject.Validation;
using System;

namespace MySushiProject.UI
{
    class Windows
    {
        const string str1 = "****************************************";
        const string str2 = "***                                  ***";
        const string str3 = "****************************************";
        public static User StartWindow(User user, bool isValid, string errMes)
        {
            Log.logger.Debug($"Открыто окно StartWindow");
            int numdStr = 0;
            Console.Clear();
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;

            string mes1 = "Здравствуйте!";
            numdStr = 10;
            mes1.WriteTextCenter(numdStr);

            string mes2 = "Как Вас зовут?";
            numdStr = 12;
            mes2.WriteTextCenter(numdStr);


            if (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

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

            Console.SetCursorPosition(width/2, 16);
            Console.CursorVisible = true;


            //*********************************************
            //user.Name = Console.ReadLine();
            //*********************************************



            user.Name = user.Name.PrintTextCenter(16);
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




            Console.CursorVisible = false;

            return user;
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
