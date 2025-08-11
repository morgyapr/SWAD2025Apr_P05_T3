using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAlReady.Models
{
    public class Order
    {
        private static int _nextId = 1;

        public int OrderId { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Status { get; private set; } = "Pending";
        public string PickupTime { get; set; }

        public static decimal CalculateSubtotal(List<CartItem> items) =>
            items?.Sum(i => i.Price * i.Quantity) ?? 0m;

        public static decimal ApplyDiscounts(int userId, decimal subtotal) => subtotal;

        public static Order CreatePendingOrder(OrderDetails d) =>
            new Order
            {
                OrderId = _nextId++,
                TotalAmount = d?.TotalAmount ?? 0m,
                PickupTime = d?.PickupTime,
                Status = "Pending"
            };

        public void UpdateStatus(string status) => Status = status;

        public string GenerateQRCode() => $"QR-{OrderId}-{Guid.NewGuid():N}".Substring(0, 12);
    }
}
