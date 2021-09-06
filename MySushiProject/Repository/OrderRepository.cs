using MySushiProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySushiProject.Repository
{
    class OrderRepository : IRepository<Order>
    {
        List<Order> _orders = new List<Order>();

        public OrderRepository()
        {
            Logger.Log.logger.Debug($"Создание JSON {this.ToString()}");
            string json;
            try
            {
                json = File.ReadAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\OrderRep.json", Encoding.UTF8);
                _orders =  JsonConvert.DeserializeObject<List<Order>>(json);
                if (_orders == null)
                {
                    _orders = new List<Order>();
                }

            }
            catch (FileNotFoundException)
            {
                //throw new FileNotFoundException();
                Logger.Log.logger.Debug($"Не найден файл JSON  {this.ToString()}");

                FileStream fs = File.Create(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\OrderRep.json");
                fs.Close();

                if (_orders == null)
                {
                    _orders = new List<Order>();
                }

                Logger.Log.logger.Debug($"Создан новый файл JSON {this.ToString()}");
            }
            Logger.Log.logger.Debug($"Конец создания JSON {this.ToString()}") ;
        }
        public void Add(Order item)
        {
            _orders.Add(item);
            UpdateRepo();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public Order GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }

        public void UpdateRepo()
        {
              string text = JsonConvert.SerializeObject(_orders);

              File.WriteAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\OrderRep.json", text);
        }
    }
}
