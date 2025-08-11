using OrderAlReady.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAlReady.Models
{
    public class FoodStall
    {
        public int StallId { get; }
        public string Name { get; }
        public List<TimeSlot> AvailableSlots { get; } = new();

        public FoodStall(int id, string name)
        {
            StallId = id; Name = name;
            AvailableSlots.AddRange(new[]
            {
                new TimeSlot { Time = "12:00 PM" },
                new TimeSlot { Time = "12:30 PM" },
                new TimeSlot { Time = "01:00 PM" }
            });
        }

        public static List<FoodStall> GetOperationalStalls() =>
            new() { new FoodStall(1, "Nasi Lemak"), new FoodStall(2, "Noodles") };

        public bool ReserveSlot(string slot)
        {
            var s = AvailableSlots.FirstOrDefault(x => x.Time == slot);
            if (s is { IsAvailable: true }) { s.IsAvailable = false; return true; }
            return false;
        }

        public void ReleaseSlot(string slot)
        {
            var s = AvailableSlots.FirstOrDefault(x => x.Time == slot);
            if (s != null) s.IsAvailable = true;
        }

        public void NotifyNewOrder(int orderId, Order order) =>
            Console.WriteLine($"Stall {Name} notified of new order {orderId}.");
    }
}
