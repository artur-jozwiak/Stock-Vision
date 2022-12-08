using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class FullOrderBook 
    {
        public Guid Id { get; set; }

        public virtual AskOrderBook? AskOrderBook { get; set; }  = new AskOrderBook();
        public Guid AskOrderBookId { get; set; }

        public virtual BidOrderBook? BidOrderBook { get; set; } = new BidOrderBook();
        public Guid BidOrderBookId { get; set; }


    }
}
