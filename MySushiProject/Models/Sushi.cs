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
    }
}
