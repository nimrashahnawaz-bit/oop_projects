using BMW_Car_Showroom.Cars;
using BMW_Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.TestDrive
{
    internal class TestDriveService
    {
        private readonly TestDriveRepo repo;
        private readonly CarsService carsService;

        public TestDriveService()
        {
            repo = new TestDriveRepo();
            carsService = new CarsService();
        }

        public bool BookTestDrive(string name, string carName, string phone, DateTime date)
        {
            CarsModel car = carsService.SearchByName(carName);
            if (car == null)
            {
                return false; 
            }

            TestDriveModel newBooking = new TestDriveModel(name, carName, phone, date);
            repo.SaveInFile(newBooking);
            return true;
        }

        public List<TestDriveModel> GetAllBookings()
        {
            return repo.GetAllBookings();
        }
    }
}
