using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Users
{
    class User
    {
        public Guid Id { get;} = Guid.NewGuid();

        //[Required(ErrorMessage ="Поле Имя не должно быть пустым")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Поле Телефон не должно быть пустым")]
        [Phone(ErrorMessage = "Введен не корректный номер")]
        public string Phone { get; set; }

        //[Required(ErrorMessage = "Поле Email не должно быть пустым")]
        [EmailAddress(ErrorMessage = "Введен не корректный Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Поле Адрес не должно быть пустым")]
        public string Address { get; set; }

        
        public override string ToString()
        {
            return $"{Name} {Address}";
        }

    }
}
