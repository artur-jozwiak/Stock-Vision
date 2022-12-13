using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class Company
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public string Branch { get; set; }
        public virtual OrderBook? OrderBook { get; set; }
        public Guid  OrderBookId { get; set; }
        public List<string> Indexes { get; set; }
    }
}
