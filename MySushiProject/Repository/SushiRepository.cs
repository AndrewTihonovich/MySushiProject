using MySushiProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySushiProject.Repository
{
    class SushiRepository
    {
        List<BasketOrder> _sushis = new List<BasketOrder>();

        public  SushiRepository()
        {
            Logger.Log.logger.Debug($"Создание JSON {this.ToString()}");
            string json;
            try
            {
                json = File.ReadAllText(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\SushiRep.json", Encoding.UTF8);
                _sushis = JsonConvert.DeserializeObject<List<BasketOrder>>(json);
                if (_sushis == null)
                {
                    _sushis = new List<BasketOrder>();
                }

            }
            catch (FileNotFoundException)
            {
                Logger.Log.logger.Debug($"Не найден файл JSON  {this.ToString()}");

                FileStream fs = File.Create(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\SushiRep.json");
                fs.Close();

                if (_sushis == null)
                {
                    _sushis = new List<BasketOrder>();
                }

                Logger.Log.logger.Debug($"Создан новый файл JSON {this.ToString()}");
            }
            Logger.Log.logger.Debug($"Конец создания JSON {this.ToString()}");
        }
            
        public List<BasketOrder> GetAll()
        {
            return _sushis; 
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
