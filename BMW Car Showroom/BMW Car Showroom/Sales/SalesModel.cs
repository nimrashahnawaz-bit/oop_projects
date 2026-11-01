using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BMW_Car_Showroom.Sales
{
    internal class SalesModel
    {
        public string CustomerName { get; set; }
        public string CarName { get; set; }
        public float Amount { get; set; }

        public SalesModel(string customerName, string carName, float amount)
        {
            CustomerName = customerName;
            CarName = carName;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{CustomerName}|{CarName}|{Amount}";
        }
    }
}
