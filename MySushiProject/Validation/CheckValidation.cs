using MySushiProject.Logger;
using MySushiProject.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Validation
{
    class CheckValidation
    {
        internal string CheckObject(object obj)
        {
            string errorMessage = null;
            //bool check = true;

            //if (string.IsNullOrWhiteSpace(obj as string))
            //{
            //    errorMessage = "Поле не может быть пустым";
            //    check = false;
            //}

            //if (check)
            //{
                var results = new List<ValidationResult>();
                var context = new ValidationContext(obj);

                if (!Validator.TryValidateObject(obj, context, results, true))
                {
                    foreach (var error in results)
                    {
                        errorMessage = error.ErrorMessage;
                    }
                    //errorMessage = results.FirstOrDefault().ToString();
                }
            //}
            return errorMessage;
        }


        internal bool isValidate(User user, string propStr, out string errMesUi, out bool isValid)
        {
            
            if (string.IsNullOrWhiteSpace(propStr))
            {
                errMesUi = "Поле не может быть пустым";
            }
            else
            { errMesUi = this.CheckObject(user); }

            if (errMesUi != null)
            {
                Log.logger.Itfo($"Не корректный ввод: \n\t\t{errMesUi}");
                isValid = false;
                return  false;
            }
            isValid = true;
            errMesUi = null;
            return true;
        }

        //internal bool gfgfd(User newUser, out bool isValid, out string errMesUi)
        //{ 
        //if (this.isValidate(newUser, newUser.Name, out errMesUi))
        //    {
        //        isValid = true;
        //        //listMenuWindows++;
        //        errMesUi = null;
        //    }
        //    else { isValid = false; }
        //}

    }
}
