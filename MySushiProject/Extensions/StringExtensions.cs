using System;

namespace MySushiProject.Extensions
{
    static class StringExtensions
    {
        public static void WriteTextCenter(this string mes, int numdLine)
        {
            int tempLength = 0;
            int width = Console.WindowWidth;
            if (mes != "" && mes !=null )
            {
                tempLength = mes.Length;
            }

            int left = width / 2 - tempLength / 2;

            Console.SetCursorPosition(left, numdLine);
            Console.Write(mes);
            if (mes != "" && mes != null)
            {
                Console.SetCursorPosition(left + mes.Length - 1, numdLine);
            }
            else 
            { Console.SetCursorPosition(left, numdLine); }
        }
     }
}
