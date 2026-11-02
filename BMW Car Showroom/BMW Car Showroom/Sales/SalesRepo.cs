using BMW_Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Sales
{
    internal class SalesRepo
    {

        private readonly string file = "Sales.txt";

        public SalesRepo() { }

        public void SaveInFile(SalesModel sales)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(sales.ToString());
            }
        }

        public void SaveAllDataIntoFile(List<SalesModel> salesList)
        {
            File.WriteAllText(file, string.Empty);
            foreach (SalesModel sale in salesList)
            {
                SaveInFile(sale);
            }
        }

        public List<SalesModel> GetSalesFromFile()
        {
            List<SalesModel> salesList = new List<SalesModel>();

            if (!File.Exists(file)) return salesList;
            using (StreamReader stream = new StreamReader(file))
            {

                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string customerName = parts[0];
                    string carName = parts[1];
                    float carAmount = float.Parse(parts[2]);

                    salesList.Add(new SalesModel(customerName, carName, carAmount));
                }
            }

            return salesList;
        }


    }
}
