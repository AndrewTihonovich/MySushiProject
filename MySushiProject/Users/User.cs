using System;
using System.ComponentModel.DataAnnotations;

namespace MySushiProject.Users
{
    class User
    {
        public Guid Id { get;} = Guid.NewGuid();

        public string Name { get; set; }

        [Phone(ErrorMessage = "Введен не корректный номер")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Введен не корректный Email")]
        public string Email { get; set; }

        public string Address { get; set; }

    }
}
