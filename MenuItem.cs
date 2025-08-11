using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAlReady.Models
{
public class MenuItem
{
    public int ItemId { get; set; }   // id is unique *within* a stall
    public string Name { get; set; }
    public decimal Price { get; set; }

    public static List<MenuItem> GetAvailableItems(int stallId) =>
        stallId switch
        {
            1 => new() // Nasi Lemak stall
            {
                new MenuItem { ItemId = 1, Name = "Nasi Lemak (Chicken)", Price = 4.80m },
                new MenuItem { ItemId = 2, Name = "Coconut Rice + Egg",   Price = 3.50m },
                new MenuItem { ItemId = 3, Name = "Ikan Bilis Set",       Price = 4.20m },
            },
            2 => new() // Noodles stall
            {
                new MenuItem { ItemId = 1, Name = "Chicken Rice", Price = 4.50m },
                new MenuItem { ItemId = 2, Name = "Mee Goreng",   Price = 3.80m },
                new MenuItem { ItemId = 3, Name = "Fishball Noodles", Price = 4.00m },
            },
            _ => new() // unknown/closed stall
        };

    public static bool CheckAvailability(int stallId, int itemId) =>
        GetAvailableItems(stallId).Any(m => m.ItemId == itemId);
}
}