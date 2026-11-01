using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Feedback
{
    internal class FeedbackModel
    {
        public string CustomerName { get; set; }
        public string CarName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public FeedbackModel(string customerName, string carName, int rating, string comment)
        {
            CustomerName = customerName;
            CarName = carName;
            Rating = rating;
            Comment = comment;
        }

        public override string ToString()
        {
            return $"{CustomerName}|{CarName}|{Rating}|{Comment}";
        }
    }
}
