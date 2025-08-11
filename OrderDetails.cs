using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAlReady.Models
{
    public class OrderDetails
    {
        public List<CartItem> Items { get; set; } = new();
        public StudentUser Student { get; set; }
        public FoodStall Stall { get; set; }
        public string PickupTime { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
