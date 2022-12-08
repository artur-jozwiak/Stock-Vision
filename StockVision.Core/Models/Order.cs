using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public decimal OrdersValue { get; set; } 
        public int Quantity { get; set; }
        public decimal SharePercentage { get; set; }
    }
}
