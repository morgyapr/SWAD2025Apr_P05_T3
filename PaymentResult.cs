using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAlReady.Models
{
    public class PaymentResult
    {
        public bool Success { get; set; }
        public bool CanRetry { get; set; }
        public string FailureReason { get; set; }
        public int OrderId { get; set; }
        public string QRCode { get; set; }
    }
}
