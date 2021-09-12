using MySushiProject.Logger;
using MySushiProject.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySushiProject.Validation
{
    class CheckValidation
    {
        internal string CheckObject(object obj)
        {
            string errorMessage = null;
            
                var results = new List<ValidationResult>();
                var context = new ValidationContext(obj);

                if (!Validator.TryValidateObject(obj, context, results, true))
                {
                    foreach (var error in results)
                    {
                        errorMessage = error.ErrorMessage;
                    }
                }
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
                Log.logger.Error($"Не корректный ввод: {errMesUi}");
                isValid = false;
                return  false;
            }
            isValid = true;
            errMesUi = null;
            return true;
        }
    }
}
