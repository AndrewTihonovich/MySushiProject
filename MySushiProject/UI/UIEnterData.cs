using MySushiProject.Extensions;
using MySushiProject.UI.Enum;
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
            int numdStr = 0;
            Console.Clear();
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;

            Console.ForegroundColor = ConsoleColor.White;
            numdStr = 10;
            mes1.WriteTextCenter(numdStr);

            numdStr = 12;
            mes2.WriteTextCenter(numdStr);
            Console.ForegroundColor = ConsoleColor.White;

            PaintWindowError(isValid, errMes);

            Console.SetCursorPosition(width / 2, 16);
            Console.CursorVisible = true;
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

                if (symb.Equals('\b')) //Backspase
                {
                    if (newUser != null)
                    {
                        if (newUser.Length > 0)
                        {
                            newUser = newUser.Remove(newUser.Length - 1);

                            str2.Trim('*').WriteTextCenter(16);

                        }
                    }
                }

                if (symb.Equals('\u001b')) //Esc
                {
                    listMenuWindows--;
                    newUser = null;
                    break;
                }

                newUser.WriteTextCenter(16);

            } while (!symb.Equals('\r'));

            return listMenuWindows;
        }
    }
}
