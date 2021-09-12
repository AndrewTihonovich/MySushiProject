using MySushiProject.Logger;
using MySushiProject.Models;
using MySushiProject.Sender;
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
            Log.logger.Debug($"Создание OrderRepository из файла JSON");
            string json;
            try
            {
                json = File.ReadAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\OrderRep.json", Encoding.UTF8);
                _orders = JsonConvert.DeserializeObject<List<Order>>(json);
                if (_orders == null)
                {
                    _orders = new List<Order>();
                }

                for (int i = 0; i < _orders.Count; i++)
                {
                    if (_orders[i].isCompleted == false)
                    {
                        _orders[i].OrderComplited += EmailSender.OrderComplited;
                    }

                    if (_orders[i].isDelivered == false)
                    {
                        _orders[i].OrderDelivered += EmailSender.OrderDelivered;
                    }

                    if (_orders[i].isPaid == false)
                    {
                        _orders[i].OrderPaid += EmailSender.OrderPaid;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Log.logger.Error($"Не найден файл OrderRep.JSON");

                FileStream fs = File.Create(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\OrderRep.json");
                fs.Close();

                if (_orders == null)
                {
                    _orders = new List<Order>();
                }

                Log.logger.Debug($"Создан новый файл OrderRep.JSON");
            }
            Log.logger.Debug($"Конец создания OrderRepository") ;
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
