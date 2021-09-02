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
    class SushiRepository : IRepository<BasketOrder>
    {
        
        List<BasketOrder> _sushis = new List<BasketOrder>();

        public  SushiRepository()
        {
            string json;
            try
            {
                json = File.ReadAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\FileJSON.json", Encoding.UTF8);
                _sushis = JsonConvert.DeserializeObject<List<BasketOrder>>(json);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Не найден файл JSON");
                throw new FileNotFoundException();
            }
        
        }
            

        public void Add(BasketOrder item)
        {
            _sushis.Add(item); 
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<BasketOrder> GetAll()
        {
            return _sushis; 
        }

        public BasketOrder GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(BasketOrder item)
        {
            throw new NotImplementedException();
        }

        public static double TotalCoastOrder(List<BasketOrder> orders)
        {
            double totalCoast = 0;
            foreach (var item in orders)
            {
                if (item.CoastUnit != 0)
                {
                    totalCoast = Math.Round(totalCoast + item.CoastUnit, 2);
                }
            }

            return totalCoast;
        }
    }
}
