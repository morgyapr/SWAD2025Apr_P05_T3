using System.Collections.Generic;
namespace OrderAlReady.Models
{
    public class StudentUser : UserAccount
    {
        public string UserType { get; set; } 
        public int NoShowCounter { get; set; }
        public int DailyOrderCount { get; set; }
        public List<Order> OrderHistory { get; set; }

        public StudentUser(int userId, string username, string email, string userType) 
            : base(userId, username, email)
        {
            UserType = userType;
            NoShowCounter = 0;
            DailyOrderCount = 0;
            OrderHistory = new List<Order>();
        }

        public int GetDailyOrderLimit() => UserType == "Priority" ? 8 : 5;

        public void IncrementOrderCount() => DailyOrderCount++;
    }
}