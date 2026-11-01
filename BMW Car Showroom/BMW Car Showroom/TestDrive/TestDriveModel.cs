using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.TestDrive
{
    internal class TestDriveModel
    {
        public string CustomerName { get; set; }
        public string CarName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }

        public TestDriveModel(string customerName, string carName, string phoneNumber, DateTime date)
        {
            CustomerName = customerName;
            CarName = carName;
            PhoneNumber = phoneNumber;
            Date = date;
        }

        public override string ToString()
        {
            // Formats the date (e.g., 24/04/2026)
            return $"{CustomerName}|{CarName}|{PhoneNumber}|{Date:dd/MM/yyyy}";
        }
    }
}
