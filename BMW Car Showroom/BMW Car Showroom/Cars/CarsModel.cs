using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Models
{
    internal class CarsModel
    {
            public string Name { get; set; }
            public float Price { get; set; }
            public int Stock { get; set; }

        public CarsModel( string name, float price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{Name}|{Price}|{Stock}";
        }
    }
}
