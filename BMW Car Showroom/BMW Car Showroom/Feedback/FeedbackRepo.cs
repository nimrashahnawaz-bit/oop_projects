using BMW_Car_Showroom.Sales;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Feedback
{
    internal class FeedbackRepo
    {
        private readonly string file = "Feedback.txt";

        public FeedbackRepo() { }

        public void SaveInFile(FeedbackModel feedback)
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(feedback.ToString());
            }
        }

        public List<FeedbackModel> GetFeedBackFromFile()
        {
            List<FeedbackModel> feedbackList = new List<FeedbackModel>();

            if (!File.Exists(file)) return feedbackList;
            using (StreamReader stream = new StreamReader(file))
            {
                
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string customerName = parts[0];
                    string carName = parts[1];
                    int rating = int.Parse(parts[2]);
                    string comment = parts[3];

                    feedbackList.Add(new FeedbackModel(customerName, carName, rating, comment));
                }
            }

            return feedbackList;
        }
    }
}

