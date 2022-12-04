using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.BLL.Models
{
    public class Company
    {
        public int id { get; set; } 
        public string Name { get; set; }
        public string Symbol { get; set; }
        public ICollection<BuyOrderSheet> BuyOrders { get; set; }
        public ICollection<SaleOrderSheet> SaleOrders { get; set; }
    }
}
