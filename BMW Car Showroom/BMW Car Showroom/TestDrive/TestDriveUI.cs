using BMW_Car_Showroom.Cars;
using BMW_Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.TestDrive
{
    internal class TestDriveUI
    {
        private readonly TestDriveService service;
        private readonly CarsService carsService;

        public TestDriveUI()
        {
            service = new TestDriveService();
            carsService = new CarsService(); // Needed to show available cars
        }

        // For Customer Menu
        public void BookTestDrive()
        {
            Console.Clear();
            Console.WriteLine("=========== BOOK A TEST DRIVE ===========");

            // show all cars
            List<CarsModel> allcar = carsService.GetAllData();
            foreach (CarsModel c in allcar)
            {
                if (c.Stock > 0) Console.WriteLine(c.ToString());
            }

            Console.Write("\nEnter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Car Name you want to test: ");
            string car = Console.ReadLine();

            Console.Write("Enter your Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Date (YYYY-MM-DD): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            

            bool success = service.BookTestDrive(name, car, phone, date);

            if (success)
            {
                Console.WriteLine("\n=======================================");
                Console.WriteLine("           TEST DRIVE CONFIRMED       ");
                Console.WriteLine("=========================================");
                Console.WriteLine($"Location: BMW Showroom, 123 Luxury Avenue");
                Console.WriteLine($"Please bring your valid driving license!");
            }
            else
            {
                Console.WriteLine("\nError: Car not found in our showroom!");
            }
            Console.ReadKey();
        }

        // For Sales Team Menu
        public void ShowAllBookings()
        {
            Console.Clear();
            Console.WriteLine("========= TEST DRIVE BOOKINGS =========");

            List<TestDriveModel> bookings = service.GetAllBookings();

            if (bookings.Count == 0)
            {
                Console.WriteLine("No test drives booked yet.");
            }
            else
            {
                foreach (TestDriveModel b in bookings)
                {
                    Console.WriteLine(b.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
