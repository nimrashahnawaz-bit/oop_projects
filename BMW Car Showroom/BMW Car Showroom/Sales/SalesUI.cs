using BMW_Car_Showroom.Cars;
using BMW_Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Sales
{
    internal class SalesUI
    {
        private readonly SalesService salesService;
        private readonly CarsService carsService;

        public SalesUI()
        {
            salesService = new SalesService();
            carsService = new CarsService();
        }
        
        public void BookCar()
        {
            Console.WriteLine("============= Book A Car =============");
            // show all cars
            List<CarsModel> car = carsService.GetAllData();
            foreach (CarsModel c in car)
            {
                if (c.Stock > 0) Console.WriteLine(c.ToString());
            }
             
            Console.WriteLine("\nEnter Car Name to buy: ");
            string carName = Console.ReadLine();

            // Find the car 
            CarsModel selectedCar = carsService.SearchByName(carName);

            if (selectedCar == null || selectedCar.Stock == 0)
            {
                Console.WriteLine("Car not found or out of stock!");
                return;
            }
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();
            salesService.RecordSale(name, selectedCar.Name, selectedCar.Price);
            Console.WriteLine($"Congrats! You booked {selectedCar.Name}.");
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        public void ShowSalesReport()
        {
            Console.Clear();
            Console.WriteLine("=========== SALES REPORT ==========");
            List<SalesModel> sales = salesService.GetAllSales();

            if (sales.Count == 0)
            {
                Console.WriteLine("No sales yet.");
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                return;
            }

            int count = 1;
            foreach (SalesModel s in sales)
            {
                Console.WriteLine($"{count}. {s.CustomerName} bought {s.CarName} for ${s.Amount}");
                count++;
            }
            Console.WriteLine($"Total Cars Sold: {sales.Count}");
            Console.WriteLine($"Total Revenue:   ${salesService.GetTotalRevenue()}");
            Console.WriteLine($"Average Sale:    ${salesService.GetAverageSale()}");
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }


        public void ShowProfitCalculator()
        {
            Console.Clear();
            Console.WriteLine("=========== Profit Calculator ==========");
            List<SalesModel> sales = salesService.GetAllSales();

            if (sales.Count == 0)
            {
                Console.WriteLine("No sales record yet.");
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Total Revenue: ${salesService.GetTotalRevenue()}");
            Console.WriteLine($"Total Profit:  ${salesService.GetTotalProfit()}");
            Console.WriteLine($"Profit Margin: {salesService.GetProfitMargin()}%");

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}
