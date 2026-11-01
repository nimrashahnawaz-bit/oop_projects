using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_Car_Showroom.Feedback
{
    internal class FeedbackUI
    {
        private readonly FeedbackService service;

        public FeedbackUI()
        {
            service = new FeedbackService();
        }
         // for Customer menu
        public void GiveFeedback()
        {
            Console.Clear();
            Console.WriteLine("========== GIVE FEEDBACK =========");

            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Car Name: ");
            string car = Console.ReadLine();

            Console.Write("Rate us (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            Console.Write("Share your comments: ");
            string comment = Console.ReadLine();

            bool success = service.SubmitFeedback(name, car, rating, comment);

            if (success)
                Console.WriteLine("\nTHANK YOU FOR YOUR FEEDBACK!");
            else
                Console.WriteLine("\nError: Rating must be between 1 and 5.");

            Console.ReadKey();
        }
         // for sales team menu
        public void ViewAllFeedback()
        {
            Console.Clear();
            Console.WriteLine("========== CUSTOMER FEEDBACK =========");

            List<FeedbackModel> feedbacks = service.GetAllFeedbacks();

            if (feedbacks.Count == 0)
            {
                Console.WriteLine("No feedback submitted yet.");
                Console.ReadKey();
                return;
            }

            foreach (FeedbackModel f in feedbacks)
            {
                Console.WriteLine(f.ToString());
            }

            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Average Rating: {service.GetAverageRating():F1}/5");
            Console.WriteLine($"Status: {service.GetRatingVerdict()}");

            Console.ReadKey();

        }
    }
}
