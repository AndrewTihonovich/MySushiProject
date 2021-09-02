using MySushiProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySushiProject.Repository
{
    class OrderRepository : IRepository<Order>
    {
        List<Order> _orders = new List<Order>();

        public OrderRepository()
        {
            string json;
            try
            {
                json = File.ReadAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\OrderRep.txt", Encoding.UTF8);
                _orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Не найден файл JSON");
                throw new FileNotFoundException();
            }
        }
        public void Add(Order item)
        {
            _orders.Add(item);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
