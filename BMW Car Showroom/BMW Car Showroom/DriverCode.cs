using BMW_Car_Showroom.Cars;
using BMW_Car_Showroom.Repo;
using BMW_Car_Showroom.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom
{
    internal class DriverCode
    {
        //class for the driver code

        public void start()
        {
            CarsUI carUI = new CarsUI();


            while (true) 
            {
                Console.Clear();
                string option = Menu();

                if (option == "1")
                {
                    carUI.CarSaleTeamDriver();
                }
                else if (option == "2")
                {
                    carUI.CarCustomerDriver();
                }
                else if (option == "3") 
                {
                    break;
                }
            }
        }

        public string Menu()
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("                        BMW SHOWROOM SCREEN                         ");
            Console.WriteLine("                    The Ultimate Driving Machine                    ");
            Console.WriteLine("====================================================================");
            Console.WriteLine("User Options: ");
            Console.WriteLine("1. Sales Team");
            Console.WriteLine("2. Customer");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. EXIT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choice one of the above options: ");
            string option = Console.ReadLine();
            return option;
        }
    }
}
