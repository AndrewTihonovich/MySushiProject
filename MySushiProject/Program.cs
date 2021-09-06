﻿using MySushiProject.Logger;
using MySushiProject.Logger.Enum;
using MySushiProject.Service;
using System;
using System.Net;
using System.Net.Mail;

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

            Console.SetWindowSize(100, 40);
            Log.logger.Debug("Изменен размер консольного окна");

            //    ******************   StartSushiService   ******************
            SushisService.SushiServiceStart();
            //    ******************   StartSushiService   ******************

        }
    }
}

