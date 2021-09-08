using MySushiProject.Logger.Enum;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MySushiProject.Logger
{
    static class Log
    {
        public static MyLogger logger;
        public static void CreateLogger()
        {
            logger = new MyLogger();
            //return logger;
        }
    }

    class MyLogger
    {
        string _path;  //= @"C:\Users\Andre\source\repos\MyLogger\MyLogger\Logs\";
        int _sizeLogFile;
        MinLogLevel _minLogLevel;
        string _logTag;

        public void LogConfig(string path, int maxSizeFile, MinLogLevel minLogLevel)
        {
            _path = path;
            _sizeLogFile = maxSizeFile;
            _minLogLevel = minLogLevel;
        }

        public void Debug(string message)
        {
            _logTag = "DBG";
            Logging(message);
        }

        public void Info(string message)
        {
            _logTag = "INF";
            Logging(message);
        }

        public void Error(string message)
        {
            _logTag = "ERR";
            Logging(message);
        }

        private bool IsWriteLog()
        {
            switch (_minLogLevel)
            {
                case MinLogLevel.Debug:
                    if (_logTag == "DBG" || _logTag == "INF" || _logTag == "ERR")
                    {
                        return true;
                    }
                    break;

                case MinLogLevel.Info:
                    if (_logTag == "INF" || _logTag == "ERR")
                    {
                        return true;
                    }
                    break;

                case MinLogLevel.Error:
                    if (_logTag == "ERR")
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        private void Logging(string message)
        {
            if (IsWriteLog())
            {
                int count = 1;
                int lastCountToday;
                string[] files;
                DateTime dtn = DateTime.Now;
                string nameFileToday = dtn.ToString("yyyyMMdd");

                // получить список файлов
                // _pach не должен быть равным null
                files = Directory.GetFiles(_path)
                                 .Where(x => x.EndsWith(".txt"))
                                 .Where(x => x.Contains(nameFileToday))
                                 .ToArray();
                // получить список файлов

                if (files.Length != 0)   //  !=0  есть сегодняшние?
                {
                    //********    найти/определить lastCountToday   *********
                    lastCountToday = FindLastCountTodayFile(files);
                    //********    найти/определить lastCountToday   *********

                    count = lastCountToday;

                    FileInfo fileInfo = new FileInfo($"{_path}" + $"log {nameFileToday}_[{count}].txt");
                    if (fileInfo.Length >= _sizeLogFile)
                    {
                        count++;
                        CreateLogFile(count, nameFileToday);
                    }
                }
                else
                {
                    count = 1;
                    CreateLogFile(count, nameFileToday);
                }

                // *************** ЗАПИСЬ ******************
                WriteInLogFile(message, count, nameFileToday);
            }
        }

        private void WriteInLogFile(string message, int count, string nameFileToday)
        {
            StackTrace st = new StackTrace();
            var method = st.GetFrame(3).GetMethod().Name;
            var namesp = st.GetFrame(3).GetMethod().ReflectedType.Namespace;

            using (FileStream fstream = new FileStream($"{_path}" + $"log {nameFileToday}_[{count}].txt", FileMode.Append))
            {
                string text = $"{DateTime.Now} [{_logTag}] : {namesp}  ***method***  {method}" +
                              $"\n\t\t\t\t\t\t\t\t{message}\n";
                byte[] array = Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
            }
        }

        private int FindLastCountTodayFile(string[] files)
        {
            int lastCountToday = 1;

            for (int i = 0; i < files.Length; i++)
            {
                string[] A = files[i].Split('_');
                string strA = A[A.Length - 1];
                strA = strA.Remove(0, 1);
                int temp = int.Parse(strA.Remove(strA.Length - 5, 5));
                if (temp > lastCountToday)
                {
                    lastCountToday = temp;
                }
            }
            return lastCountToday;
        }

        private void CreateLogFile(int count, string nameFileToday)
        {
            FileStream fs = File.Create($"{_path}" + $"log {nameFileToday}_[{count}].txt");
            fs.Close();
        }
    }

    
}

