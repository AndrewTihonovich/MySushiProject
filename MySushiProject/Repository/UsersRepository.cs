using MySushiProject.Logger;
using MySushiProject.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySushiProject.Repository
{
    class UsersRepository : IRepository<User>
    {
        List<User> _users = new List<User>();

        public UsersRepository()
        {
            Log.logger.Debug($"Создание UsersRepository из файла JSON");
            string json;
            try
            {
                json = File.ReadAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\UserRep.json", Encoding.UTF8);
                _users = JsonConvert.DeserializeObject<List<User>>(json);
                if (_users == null)
                {
                    _users = new List<User>();
                }

            }
            catch (FileNotFoundException)
            {
                Log.logger.Error($"Не найден файл UsersRep.JSON");

                FileStream fs = File.Create(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\UserRep.json");
                fs.Close();

                if (_users == null)
                {
                    _users = new List<User>();
                }

                Log.logger.Debug($"Создан новый файл UsersRep.JSON");
            }
            Log.logger.Debug($"Конец создания UsersRepository");
        }
        public void Add(User item)
        {
            _users.Add(item);
            UpdateRepo();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        public void UpdateRepo()
        {
            string text = JsonConvert.SerializeObject(_users);

            File.WriteAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\UserRep.json", text);
        }
    }
}
