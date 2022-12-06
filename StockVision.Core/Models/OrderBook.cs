using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public abstract class OrderBook
    {
        public Company Company { get; set; }
        public ICollection<Order> Orders { get; }

    }
}
