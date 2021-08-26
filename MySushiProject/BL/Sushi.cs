using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MySushiProject.BL
{
    class Sushi
    {
        //static int _id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public double Coast { get; set; }
        public string Description { get; set; }

        public Sushi( int id, string name, double coast, string description)
        {
            //id++;
            Id = id;
            Name = name;
            Coast = coast;
            Description = description;
        }

        public List<BasketOrder> SushiListJSON()
        {
            List<BasketOrder> sushis = new List<BasketOrder>();

            //sushis.Add(new Sushi(1, "Текка маки", 7.3));
            //sushis.Add(new Sushi(2, "Авокадо макии", 5.5));
            //sushis.Add(new Sushi(3, "Каппа маки", 4.5));
            //sushis.Add(new Sushi(4, "Спайси кунсей маки", 8.5));
            //sushis.Add(new Sushi(5, "Кияри маки", 12.6));

            //string str = System.Text.Json.JsonSerializer.Serialize(sushis);

            //using (FileStream fs = new FileStream("FileJSON.json", FileMode.OpenOrCreate))
            //{
            //    string str = fs.ToString();



            //}

            //using (Stream fs = openDialog.OpenFile())
            //using (StreamReader sr = new StreamReader(fs))
            //using (JsonTextReader jr = new JsonTextReader(sr))
            //string json = "[{\"Id\":1,\"Name\":\"\\u0422\\u0435\\u043A\\u043A\\u0430 \\u043C\\u0430\\u043A\\u0438\",\"Coast\":7.3},{\"Id\":2,\"Name\":\"\\u0410\\u0432\\u043E\\u043A\\u0430\\u0434\\u043E \\u043C\\u0430\\u043A\\u0438\\u0438\",\"Coast\":5.5},{\"Id\":3,\"Name\":\"\\u041A\\u0430\\u043F\\u043F\\u0430 \\u043C\\u0430\\u043A\\u0438\",\"Coast\":4.5},{\"Id\":4,\"Name\":\"\\u0421\\u043F\\u0430\\u0439\\u0441\\u0438 \\u043A\\u0443\\u043D\\u0441\\u0435\\u0439 \\u043C\\u0430\\u043A\\u0438\",\"Coast\":8.5},{\"Id\":5,\"Name\":\"\\u041A\\u0438\\u044F\\u0440\\u0438 \\u043C\\u0430\\u043A\\u0438\",\"Coast\":12.6}]";
            //string json = "[{\"Name\":\"\\u0422\\u0435\\u043A\\u043A\\u0430 \\u043C\\u0430\\u043A\\u0438\",\"Coast\":7.3},{\"Name\":\"\\u0410\\u0432\\u043E\\u043A\\u0430\\u0434\\u043E \\u043C\\u0430\\u043A\\u0438\\u0438\",\"Coast\":5.5},{\"Id\":3,\"Name\":\"\\u041A\\u0430\\u043F\\u043F\\u0430 \\u043C\\u0430\\u043A\\u0438\",\"Coast\":4.5},{\"Id\":4,\"Name\":\"\\u0421\\u043F\\u0430\\u0439\\u0441\\u0438 \\u043A\\u0443\\u043D\\u0441\\u0435\\u0439 \\u043C\\u0430\\u043A\\u0438\",\"Coast\":8.5},{\"Id\":5,\"Name\":\"\\u041A\\u0438\\u044F\\u0440\\u0438 \\u043C\\u0430\\u043A\\u0438\",\"Coast\":12.6}]";
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
            //string json = File.ReadAllText(@"c:\temp\FileJSON.json", Encoding.UTF8);
            //sushis = JsonConvert.DeserializeObject<List<BasketOrder>>(json);
            return sushis;
        }

    }
}
