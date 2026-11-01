using BMW_Car_Showroom.Cars;
using BMW_Car_Showroom.Models;
using BMW_Car_Showroom.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
