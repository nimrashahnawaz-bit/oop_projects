using BMW_Car_Showroom.Models;
using BMW_Car_Showroom.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Cars
{
    internal class CarsService
    {
        private readonly CarsRepo repo;
        public CarsService()
        {
            repo = new CarsRepo();
        }

        public CarsModel SearchByName(string name)
        {
            foreach(CarsModel cars in repo.GetCarsFromFile())
            {
                if(cars.Name == name)
                {
                    return cars;
                }
            }
            return null;
        }

        public List<CarsModel> SearchByBudget(float price)
        {
            List<CarsModel> result = new List<CarsModel>();
            foreach (CarsModel cars in repo.GetCarsFromFile())
            {
                if (cars.Price <= price)
                {
                    result.Add(cars);
                }
            }
            return result;
        }

        public bool UpdateCarPrice(string name, float Updateprice)
        {
            List<CarsModel> cars = repo.GetCarsFromFile();
            foreach (CarsModel car in cars)
            {
                if(car.Name == name)
                {
                    car.Price = Updateprice;
                    repo.SaveAllDataIntoFile(cars);
                    return true;
                }
            }
            return false;
        }

        public List<CarsModel> LowStockAlret()
        {
           List<CarsModel> result = new List<CarsModel>();
            foreach (CarsModel car in  repo.GetCarsFromFile())
            {
                if (car.Stock <= 3)
                {
                    result.Add(car);
                }
            }
            return result;
        }

        public bool UpdateCarStock(string name, int UpdateStock)
        {
            List<CarsModel> cars = repo.GetCarsFromFile();
            foreach (CarsModel car in cars)
            {
                if (car.Name == name)
                {
                    car.Stock = UpdateStock;
                    repo.SaveAllDataIntoFile(cars);
                    return true;
                }
            }
            return false;
        }

        public bool ReduceStock(string name)
        {
            List<CarsModel> cars = repo.GetCarsFromFile();
            foreach (CarsModel car in cars)
            {
                if (car.Name == name)
                {
                    if (car.Stock > 0)
                    {
                        car.Stock = car.Stock - 1;
                        repo.SaveAllDataIntoFile(cars);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public List<CarsModel> GetAllData()
        {
            return repo.GetCarsFromFile();
        }

        public void SaveProduct(CarsModel cars)
        {
            repo.SaveInFile(cars);
        }

        public bool DeleteByName(string name)
        {
            List<CarsModel> cars = repo.GetCarsFromFile();
            int count = 0;
            foreach (CarsModel car in cars)
            {
                if (car.Name == name)
                {
                    cars.RemoveAt(count);
                    repo.SaveAllDataIntoFile(cars);
                    return true;
                }
                count++;
            }
            return false;
        }

        public List<CarsModel> SearchByPriceRange(float minPrice, float maxPrice)
         {
           List<CarsModel> result = new List<CarsModel>();

          foreach (CarsModel car in repo.GetCarsFromFile())
          {
            if (car.Price >= minPrice && car.Price <= maxPrice)
          {
            result.Add(car);
         }
        }
        return result;
        }

    }
}
