using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.BLL.Models
{
    public abstract class OrderSheet
    {
        public Company Company { get; set; }
        public ICollection<Order> Orders { get; }

    }
}
