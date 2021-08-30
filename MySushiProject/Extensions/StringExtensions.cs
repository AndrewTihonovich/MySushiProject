using MySushiProject.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Extensions
{
    static class StringExtensions
    {
        public static void WriteTextCenter(this string mes, int numdLine)
        {
            int tempLength = 0;
            int width = Console.WindowWidth;
            if (mes != null)
            {
                tempLength = mes.Length;
            }

            int left = width / 2 - tempLength / 2;

            Console.SetCursorPosition(left, numdLine);
            Console.Write(mes);
            if (mes != null)
            {
                Console.SetCursorPosition(left + mes.Length - 1, numdLine);
            }
        }



        public static string PrintTextCenter(this string enterStr, int numdLine)
        {
            enterStr = null;
            char symb = default;

            do
            {
                symb = Console.ReadKey().KeyChar;

                if (char.IsLetterOrDigit(symb) || symb.Equals('\b'))
                {



                    if (symb.Equals('\b'))
                    {
                        if (enterStr != null)
                        {
                            if (enterStr.Length > 0)
                            {
                                enterStr = enterStr.Remove(enterStr.Length - 1);

                                //numdStr = 16;
                                WriteTextCenter("                                ", numdLine);

                            }

                        }

                    }
                    else
                    { enterStr = enterStr + symb; }
                }
                //numdStr = 16;
                

                WriteTextCenter(enterStr, numdLine);

            } while (!symb.Equals('\r'));
            return enterStr;
        }

     }
}
