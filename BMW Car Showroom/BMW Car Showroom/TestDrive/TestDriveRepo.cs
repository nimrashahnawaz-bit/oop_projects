using BMW_Car_Showroom.Feedback;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.TestDrive
{
    internal class TestDriveRepo
    {
        private readonly string file = "TestDrive.txt";

        public TestDriveRepo() { }

        public void SaveInFile(TestDriveModel testdrive)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(testdrive.ToString());
            }
        }

        public List<TestDriveModel> GetAllBookings()
        {
            List<TestDriveModel> testdriveList = new List<TestDriveModel>();

            if (!File.Exists(file)) return testdriveList;
            using (StreamReader stream = new StreamReader(file))
            {

                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string customerName = parts[0];
                    string carName = parts[1];
                    string phoneNumber = parts[2];
                    DateTime date = DateTime.Parse(parts[3]);
                    

                    testdriveList.Add(new TestDriveModel(customerName, carName, phoneNumber, date ));
                }
            }

            return testdriveList;
        }
    }
}
