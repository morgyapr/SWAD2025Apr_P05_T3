using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FeedbackSystem
{
    public enum FeedbackStatus
    {
        Approved,
        Pending,
        Removed,
        Reviewed
    }

    internal class FeedbackReply
    {
        private FeedbackReply() { }
        public FeedbackReply(int ownerID, string replyMessage)
        {
            UserID = ownerID;
            ReplyText = replyMessage;
            Timestamp = DateTime.Now;
        }
        public int UserID { get; set; }
        public string ReplyText { get; set; }
        public DateTime Timestamp { get; set; }
    }

    internal class Feedback
    {
        static int incrementalID = 100; // static id will be shared accross all Feedback objects.

        // Private default constructor helps prevents empty object creation
        private Feedback() { }

        // Constructor with required parameters
        public Feedback(int userID, string feedbackText)
        {
            ++incrementalID;
            FeedbackID = incrementalID;
            UserID = userID;
            FeedbackText = feedbackText;
            Status = FeedbackStatus.Approved;
            flagged = false;
            Timestamp = DateTime.Now;
        }


        public int FeedbackID { get; set; }
        public int UserID { get; set; }
        public string FeedbackText { get; set; }
        public FeedbackStatus Status { get; set; }

        private bool flagged;
        public bool Flagged
        {
            get => flagged;
            set
            {
                flagged = value;
                if (flagged)
                    Status = FeedbackStatus.Pending;
            }
        }

        public DateTime Timestamp { get; set; }

        public FeedbackReply Reply { get; set; }
    }



}
