using BMW_Car_Showroom.Cars;
using BMW_Car_Showroom.Models;
using BMW_Car_Showroom.Repo;
using BMW_Car_Showroom.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BMW_Car_Showroom.Sales
{
    internal class SalesService
    {
        private readonly SalesRepo salesRepo;
        private readonly CarsService carsService;

        public SalesService()
        {
            salesRepo = new SalesRepo();
            carsService = new CarsService();
        }

        public void RecordSale(string customerName, string carName, float carPrice)
        {
            // 1. Calculate 5% tax
            float tax = carPrice * 0.05f;
            float totalAmount = carPrice + tax;

            // 2. Save the sale
            SalesModel newSale = new SalesModel(customerName, carName, totalAmount);
            salesRepo.SaveInFile(newSale);

            // 3. Reduce the car's stock in the Cars module!
            // (You will need to add a ReduceStock method to CarsService for this to work)
            carsService.ReduceStock(carName);
        }

        public float GetTotalRevenue()
        {
            float total = 0;
            foreach (var sale in salesRepo.GetSalesFromFile())
            {
                total += sale.Amount;
            }
            return total;
        }

        public float GetAverageSale()
        {
            var sales = salesRepo.GetSalesFromFile();
            if (sales.Count == 0) return 0;
            return GetTotalRevenue() / sales.Count;
        }

        public List<SalesModel> GetAllSales()
        {
            return salesRepo.GetSalesFromFile();
        }

        public float GetTotalProfit()
        {
            float totalProfit = 0;
            foreach (var sale in salesRepo.GetSalesFromFile())
            {
                // Assuming cost is 90% of the sale amount (10% profit)
                float cost = sale.Amount * 0.90f;
                totalProfit += (sale.Amount - cost);
            }
            return totalProfit;
        }

        public float GetProfitMargin()
        {
            float revenue = GetTotalRevenue();
            if (revenue == 0) return 0; // Prevent divide by zero

            return (GetTotalProfit() / revenue) * 100;
        }

        // code for numeric range
        public List<SalesModel> SearchByPriceRange(float minPrice, float maxPrice)
        {
            List<SalesModel> result = new List<SalesModel>();

            foreach (SalesModel s in salesRepo.GetSalesFromFile())
            {
                if (s.Amount >= minPrice && s.Amount <= maxPrice)
                {
                    result.Add(s);
                }
            }
            return result;
        }

        //category Search
        public void SearchByCategory(string name)
        {
            if (name == "Customer" || name == "customer")
            {
                //logic for customer search
                SearchByCustomerName(name);
            }
            
            if(name == "car" || name == "Car")
            {
                // logic for car search
                SearchByCarName(name);
            }
            
        }

        //customer name searching
        public List<SalesModel> SearchByCustomerName(string n)
        {
            List<SalesModel> result = new List<SalesModel>();
            foreach (SalesModel c in salesRepo.GetSalesFromFile())
            {
                if (c.CustomerName == n)
                {
                    result.Add(c);
                }
            }
            return result;
        }

        // carname searching
        public List<SalesModel> SearchByCarName(string n)
        {
            List<SalesModel> result = new List<SalesModel>();
            foreach (SalesModel c in salesRepo.GetSalesFromFile())
            {
                if (c.CarName == n)
                {
                    result.Add(c);
                }
            }
            return result;
        }

    }
}
