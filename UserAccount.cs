// Abstract base for all user accounts
namespace OrderAlReady.Models
{
    public abstract class UserAccount
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string AccountStatus { get; set; }

        public UserAccount(int userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
            AccountStatus = "Active";
        }
    }
}