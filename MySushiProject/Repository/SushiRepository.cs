using MySushiProject.Logger;
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
            Log.logger.Debug($"Создание SushiRepository из файла JSON");
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
                Log.logger.Error($"Не найден файл SushiRep.JSON");

                FileStream fs = File.Create(@"C:\Users\Andre\source\repos\MySushiProject\MySushiProject\Repository\Data\SushiRep.json");
                fs.Close();

                if (_sushis == null)
                {
                    _sushis = new List<BasketOrder>();
                }

                Log.logger.Debug($"Создан новый файл SushiRep.JSON");
            }
            Log.logger.Debug($"Конец создания SushiRepository");
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
