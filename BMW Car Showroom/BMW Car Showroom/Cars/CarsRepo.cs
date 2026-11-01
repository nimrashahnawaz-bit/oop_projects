using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BMW_Car_Showroom.Models;

namespace BMW_Car_Showroom.Repo
{
    internal class CarsRepo
    {
        private readonly string file = "Cars.txt";

        public CarsRepo() { }

        public void SaveInFile(CarsModel car)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(car.ToString());
            }
        }

        public void SaveAllDataIntoFile(List<CarsModel> carsList)
        {
            File.WriteAllText(file, string.Empty);
            foreach (CarsModel car in carsList)
            {
                SaveInFile(car);
            }
        }

        //string name, float price, int stock
        public List<CarsModel> GetCarsFromFile()
        {
            List<CarsModel> carsList = new List<CarsModel>();

            if (!File.Exists(file)) return carsList;
            using (StreamReader stream = new StreamReader(file))
            {

                string line = "";
                while((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string carName = parts[0];
                    float carPrice = float.Parse(parts[1]);
                    int carStock = int.Parse(parts[2]);

                    carsList.Add(new CarsModel (carName, carPrice, carStock));
                }
             }
            
           return carsList;
        }
    }

}
