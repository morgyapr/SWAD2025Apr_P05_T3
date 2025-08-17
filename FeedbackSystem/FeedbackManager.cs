using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem
{
    // Assuming per Owner owns a feedback manager to manage feedback.
    internal class FeedbackManager
    {
        public FeedbackManager(string storeName, int ownerId)
        {
            OwnerId = ownerId; // hardcoded for demo purpose
            StoreName = storeName;
            FeedbackList = new List<Feedback>();
        }
        int OwnerId { get; set; }
        string StoreName { get; set; }
        List<Feedback> FeedbackList { get; set; }

        public void ViewReviews()
        {
            Console.WriteLine($"\n--- Feedbacks for {StoreName} ---");
            foreach (var fb in FeedbackList)
            {
                if (fb.Status == FeedbackStatus.Removed)
                {
                    continue;
                }
                Console.WriteLine($"ID: {fb.FeedbackID} | User: {fb.UserID} | Status: {fb.Status} | Flagged: {fb.Flagged}");
                Console.WriteLine($"Date: {fb.Timestamp:dd/MM/yyyy hh:mm tt}");
                Console.WriteLine($"Text: {fb.FeedbackText}");

                if (fb.Reply != null && !string.IsNullOrEmpty(fb.Reply.ReplyText))
                {
                    Console.WriteLine($"    Reply: {fb.Reply.ReplyText}");
                    Console.WriteLine($"    Reply Date: {fb.Reply.Timestamp:dd/MM/yyyy hh:mm tt}");
                }

                Console.WriteLine("------------------------");

            }
        }

        public void ReplyReview()
        {
            Console.Write("Enter Feedback ID to reply: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var fb = FeedbackList.Find(f => f.FeedbackID == id);
                if (fb != null)
                {
                    if (fb.Reply != null && !string.IsNullOrEmpty(fb.Reply.ReplyText))
                    {
                        Console.WriteLine("This feedback already has a reply.");
                        return;
                    }

                    // Pending cannot make reply, until Reviewed then can continue Reply.
                    if (fb.Status == FeedbackStatus.Pending)
                    {
                        Console.WriteLine("This feedback is pending Platform Operator to review first. You are not allow to reply yet.");
                        return;
                    }

                    // Removed cannot make reply anymore.
                    if (fb.Status == FeedbackStatus.Removed)
                    {
                        Console.WriteLine("This feedback has been removed by Platform Operator. You are not allow to reply anymore.");
                        return;
                    }

                    Console.Write("Enter your reply: ");
                    string feedbackText = Console.ReadLine();
                    fb.Reply = new FeedbackReply(OwnerId, feedbackText);
                    fb.Status = FeedbackStatus.Reviewed;
                    Console.WriteLine("Reply added successfully!");
                }
                else
                {
                    Console.WriteLine("Feedback not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void ReportReview()
        {
            Console.Write("Enter Feedback ID to report: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var fb = FeedbackList.Find(f => f.FeedbackID == id);
                if (fb != null)
                {
                    fb.Flagged = true;
                    fb.Status = FeedbackStatus.Pending;
                    Console.WriteLine("Feedback has been reported and marked as Pending.");
                }
                else
                {
                    Console.WriteLine("Feedback not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine($"\n{StoreName} Feedback System");
            Console.WriteLine("1. View Feedbacks");
            Console.WriteLine("2. Reply a Feedback");
            Console.WriteLine("3. Report a Feedback");
            Console.WriteLine("4. Quit");
        }

        // Pre-create feedback for demo purpose only
        public void GenerateFeedbackData()
        {
            FeedbackList.Add(new Feedback(101, "Great chicken! Crispy and hot."));
            FeedbackList.Add(new Feedback(102, "The fries were cold when delivered."));

            FeedbackList.Add(new Feedback(103, "Staff was rude and slow."));

            FeedbackList.Add(new Feedback(104, "Love the new burger!"));
            FeedbackList.Add(new Feedback(103, "This place is trash, never coming back! Disgusting food, dirty tables, and staff yelling at customers. F*** y**!"));

            // Simulate removed review
            Feedback removedFb = new Feedback(103, "Your mother cant cook at all, your whole family cannot cook. ");
            removedFb.Flagged = true;
            removedFb.Status = FeedbackStatus.Removed;
            FeedbackList.Add(removedFb);

            Console.WriteLine($"\nGenerated Feedback content");
            Console.WriteLine($"\n--- Feedbacks for {StoreName} ---");
            foreach (var fb in FeedbackList)
            {

                Console.WriteLine($"ID: {fb.FeedbackID} | User: {fb.UserID} | Status: {fb.Status} | Flagged: {fb.Flagged}");
                Console.WriteLine($"Date: {fb.Timestamp:dd/MM/yyyy hh:mm tt}");
                Console.WriteLine($"Text: {fb.FeedbackText}");

                if (fb.Reply != null && !string.IsNullOrEmpty(fb.Reply.ReplyText))
                {
                    Console.WriteLine($"    Reply: {fb.Reply.ReplyText}");
                    Console.WriteLine($"    Reply Date: {fb.Reply.Timestamp:dd/MM/yyyy hh:mm tt}");
                }

                Console.WriteLine("------------------------");

            }
        }
    }
}
