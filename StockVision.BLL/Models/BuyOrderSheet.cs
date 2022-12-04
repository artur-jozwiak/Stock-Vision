using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.BLL.Models
{
    public class BuyOrderSheet : OrderSheet
    {
        public IEnumerable<OrderSheet> BuyOrderSheets { get; set; }
    }
}
