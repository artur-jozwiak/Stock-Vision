using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class OrderBook 
    {
        public int Id { get; set; }
        public DateTime LoadTime { get; set; } = DateTime.Now;

        public virtual AskOrderBook? AskOrderBook { get; set; }  = new AskOrderBook();
        public int AskOrderBookId { get; set; }

        public virtual BidOrderBook? BidOrderBook { get; set; } = new BidOrderBook();
        public int BidOrderBookId { get; set; }
    }
}
