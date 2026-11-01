using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Feedback
{
    internal class FeedbackService
    {
        private readonly FeedbackRepo repo;

        
        public FeedbackService()
        {
            repo = new FeedbackRepo();
        }

        public bool SubmitFeedback(string name, string car, int rating, string comment)
        {
            //Rating must be 1 to 5
            if (rating < 1 || rating > 5)
            {
                return false; 
            }

            FeedbackModel newFeedback = new FeedbackModel(name, car, rating, comment);
            repo.SaveInFile(newFeedback);
            return true;
        }

        public List<FeedbackModel> GetAllFeedbacks()
        {
            return repo.GetFeedBackFromFile();
        }

        
        public double GetAverageRating()
        {
            List<FeedbackModel> feedback = repo.GetFeedBackFromFile();
            if (feedback.Count == 0) return 0;

            int total = 0;
            foreach (FeedbackModel f in feedback)
            {
                total += f.Rating;
            }
            return (double)total / feedback.Count;
        }

        public string GetRatingVerdict()
        {
            double avg = GetAverageRating();
            if (avg >= 4.5) return "EXCELLENT! Customers love BMW!";
            if (avg >= 3.5) return "GOOD! Customers are satisfied!";
            if (avg >= 2.5) return "AVERAGE! Need some improvements.";
            return "POOR! Immediate action needed!";
        }
    }
}
