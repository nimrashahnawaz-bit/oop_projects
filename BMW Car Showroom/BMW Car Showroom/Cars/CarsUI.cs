using BMW_Car_Showroom.Feedback;
using BMW_Car_Showroom.Models;
using BMW_Car_Showroom.Sales;
using BMW_Car_Showroom.TestDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Cars
{
    internal class CarsUI
    {

        private readonly CarsService service;
        private readonly SalesUI salesUI;
        private FeedbackUI feedbackUI;
        private TestDriveUI testDriveUI;

        public CarsUI()
        {
            service = new CarsService();
            salesUI = new SalesUI();
            feedbackUI = new FeedbackUI();
            testDriveUI = new TestDriveUI();
        }

        // for sales team Menu
        public void CarSaleTeamDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = CarSalesMenu();
                if (option == "1")
                {
                    CarsModel car = TakeInput();
                    service.SaveProduct(car);
                }
                else if (option == "2")
                {
                    DisplayAll();
                }
                else if (option == "3")
                {
                    UpdatePrice();
                }
                else if (option == "4")
                {
                    UpdateStock();
                }
                else if (option == "5")
                {
                    DeleteCar();
                }
                else if (option == "6")
                {
                    LowStock();
                }
                else if (option == "7")
                {
                    salesUI.ShowSalesReport();
                }
                else if (option == "8")
                {
                    salesUI.ShowProfitCalculator();
                }
                else if (option == "9")
                {
                    feedbackUI.ViewAllFeedback();
                }
                else if (option == "10")
                {
                    testDriveUI.ShowAllBookings();
                }
                else if (option == "11")
                {
                    break;
                }
                else { Console.WriteLine("Wrong option selected"); }
            }
        }

        public string CarSalesMenu()
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("                    Welcome to Sales Team Menu                      ");
            Console.WriteLine("====================================================================");
            Console.WriteLine("User Options: ");
            Console.WriteLine("1. Add new Car");
            Console.WriteLine("2. View all Cars");
            Console.WriteLine("3. Update Price");
            Console.WriteLine("4. Update Stock");
            Console.WriteLine("5. Delete Car");
            Console.WriteLine("6. Low Stock Alert");
            Console.WriteLine("7. View Sales Report");
            Console.WriteLine("8. Profit Calculator");
            Console.WriteLine("9. View FeedBack");
            Console.WriteLine("10. View Test Drive Bookings");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("11. EXIT TO MAIN");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choice one of the above options: ");
            string option = Console.ReadLine();
            return option;
        }

        public void LowStock()
        {
            List<CarsModel> car = service.LowStockAlret();

            foreach (CarsModel c in car)
            {
                if (c.Stock == 0)
                {
                    Console.WriteLine($"  {c.Name}");
                    Console.WriteLine($"  OUT OF STOCK! Need urgent restock!");
                }
                else
                {
                    Console.WriteLine($" {c.Name}");
                    Console.WriteLine($" Only {c.Stock} units left! Order more soon!");
                }
            }
            Console.ReadKey();
        }
        public void UpdateStock()
        {
            Console.WriteLine("Enter Car Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Updated Car Stock: ");
            int stock = int.Parse(Console.ReadLine());

            service.UpdateCarStock(name, stock);
        }

        public void UpdatePrice()
        {
            Console.WriteLine("Enter Car Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Updated Car Price: ");
            float price = float.Parse(Console.ReadLine());

            service.UpdateCarPrice(name, price);
        }

        public void DeleteCar()
        {
            Console.WriteLine("Enter Car Name: ");
            string name = Console.ReadLine();

            service.DeleteByName(name);
        }

        public void DisplayAll()
        {
            List<CarsModel> car = service.GetAllData();
            foreach (CarsModel c in car)
            {
                if (c.Stock > 0) Console.WriteLine(c.ToString());
            }
            Console.ReadKey();
        }

        public CarsModel TakeInput()
        {
            Console.WriteLine("Enter Car Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Car Price: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock: ");
            int stock = int.Parse(Console.ReadLine());

            CarsModel car = new CarsModel(name, price, stock);
            return car;
        }






        // for customers Menu

        public void CarCustomerDriver()
        {
            while (true)
            {
                Console.Clear();
                string option = CarCustomerMenu();
                if (option == "1")
                {
                    DisplayAll();
                }
                else if (option == "2")
                {
                    SearchCar();
                }
                else if (option == "3")
                {
                    SearchCarByBudget();
                }
                else if (option == "4")
                {
                    salesUI.BookCar();
                }
                else if (option == "5")
                {
                    feedbackUI.GiveFeedback();
                }
                else if (option == "6")
                {
                    testDriveUI.BookTestDrive();
                }
                else if (option == "7")
                {
                    SearchByPriceRangeUI();
                }
                else if (option == "8")
                {
                    break;
                }
                else { Console.WriteLine("Wrong option selected"); }
            }
        }
        public string CarCustomerMenu()
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("                     Welcome to Customer Menu                       ");
            Console.WriteLine("====================================================================");
            Console.WriteLine("User Options: ");
            Console.WriteLine("1. View all Cars");
            Console.WriteLine("2. Search Car By Name");
            Console.WriteLine("3. Search By Your Budget");
            Console.WriteLine("4. Book a Car");
            Console.WriteLine("5. Give Your FeedBack");
            Console.WriteLine("6. Book a Test Drive");
            Console.WriteLine("7. Search by Price Range(Lab)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. EXIT TO MAIN");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choice one of the above options: ");
            string option = Console.ReadLine();
            return option;
        }

        public void SearchCar()
        {
            Console.WriteLine("Enter Car Name: ");
            string name = Console.ReadLine();

            CarsModel foundCar = service.SearchByName(name);

            if (foundCar == null)
            {
                Console.WriteLine("No Record Found");
            }
            else
            {
                Console.WriteLine(foundCar.ToString());
            }
            Console.ReadKey();
        }

        public void SearchCarByBudget()
        {
            Console.WriteLine("Enter Your Budget: ");
            float budget = float.Parse(Console.ReadLine());

            List<CarsModel> foundCars = service.SearchByBudget(budget);

            if (foundCars.Count == 0)
            {
                Console.WriteLine("No cars found under this budget.");
            }
            else
            {
                foreach (CarsModel car in foundCars)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            Console.ReadKey();
        }

        // lab 

        public void SearchByPriceRangeUI()
        {
            Console.Write("Enter Minimum Budget: ");
            float min = float.Parse(Console.ReadLine());

            Console.Write("Enter Maximum Budget: ");
            float max = float.Parse(Console.ReadLine());


            List<CarsModel> foundCars = service.SearchByPriceRange(min, max);

            if (foundCars.Count == 0)
            {
                Console.WriteLine("No cars found in this range.");
            }
            else
            {
                foreach (CarsModel car in foundCars)
                {
                    Console.WriteLine(car.ToString());
                }

                Console.ReadKey();
            }

        }
    }
}