using MySushiProject.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Repository
{
    class UsersRepository : IRepository<User>
    {
        List<User> _users = new List<User>();

        public UsersRepository()
        {
            string json;
            try
            {
                json = File.ReadAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\UserRep.txt", Encoding.UTF8);
                _users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Не найден файл JSON");
                throw new FileNotFoundException();
            }
        }
        public void Add(User item)
        {
            _users.Add(item);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
