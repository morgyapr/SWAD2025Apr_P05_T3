// See https://aka.ms/new-console-template for more information
using FeedbackSystem;


// Student/Special Student 
// Make a review <- target the store.


// Platform Operator
// Review Feedback X <- flagged by order staff.


/* Order Store Staff
- Read/View the feedback
- Reply the feedback
- Report, Flagged the feedback if its something inappropriate.
*/

// Assume the program now is Order Store Staff Perspective.
// Assume the feedback is made to the Store of current logged in Store Staff.


FeedbackManager feedbackDemoManager = new FeedbackManager("Burger King", 888);
feedbackDemoManager.GenerateFeedbackData();

while (true)
{
    feedbackDemoManager.PrintMenu();

    Console.Write("Enter choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            feedbackDemoManager.ViewReviews();
            break;
        case "2":
            feedbackDemoManager.ReplyReview();
            break;
        case "3":
            feedbackDemoManager.ReportReview();
            break;
        case "4":
            Console.WriteLine("Goodbye!");
            return; // Exit loop and program
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}