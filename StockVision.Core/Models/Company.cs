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

        public virtual FullOrderBook? FullOrderBook { get; set; }
        public Guid  FullOrderBookId { get; set; }


        //public AskOrderBook? AskOrderBook { get; set; }
        //public Guid AskOrderBookId { get; set; }

        //public BidOrderBook? BidOrderBook { get; set; }
        //public Guid BidOrderBookId { get; set; }

    }
}
