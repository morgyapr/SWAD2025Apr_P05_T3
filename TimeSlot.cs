using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAlReady.Models
{
    public class TimeSlot
    {
        public string Time { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
