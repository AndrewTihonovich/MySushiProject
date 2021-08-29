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
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        
        public override string ToString()
        {
            return $"{Name} {Address}";
        }

    }
}
