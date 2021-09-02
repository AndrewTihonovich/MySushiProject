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
        internal string CheckProperty(object obj)
        {
            string errorMessage=null;
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
            return errorMessage;
        }

        
    }
}
