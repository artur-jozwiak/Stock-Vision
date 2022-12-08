﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class BidOrderBook 
    {
        public Guid Id { get; set; }
        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
    }
}
