using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class Company
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Symbol { get; set; }
        public AskOrderBook? BuyOrders { get; set; }
        public BidOrderBook? SaleOrders { get; set; }
    }
}
