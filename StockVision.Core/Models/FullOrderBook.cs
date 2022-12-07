using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class FullOrderBook 
    {
        public Company? Company { get; set; }
        //public ICollection<Order> Orders { get; set; }
        //public ICollection<Order> Orders { get; set; }

        public AskOrderBook AskOrderBook { get; set; }  = new AskOrderBook();
        public BidOrderBook BidOrderBook { get; set; } = new BidOrderBook();
    }
}
