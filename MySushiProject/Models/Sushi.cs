using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySushiProject.Models
{
    class Sushi
    {
        public int Id { get; }
        public string Name { get; set; }
        public double Coast { get; set; }
        public string Description { get; set; }

        public Sushi( int id, string name, double coast, string description)
        {
            Id = id;
            Name = name;
            Coast = coast;
            Description = description;
        }

        public List<BasketOrder> SushiListJSON()
        {
            List<BasketOrder> sushis = new List<BasketOrder>();
            
            string json;
            try
            {
                json = File.ReadAllText(@"c:\temp\FileJSON.json", Encoding.UTF8);
                sushis = JsonConvert.DeserializeObject<List<BasketOrder>>(json);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Не найден файл JSON");
                throw new FileNotFoundException();
            }
            
            return sushis;
        }
    }
}
