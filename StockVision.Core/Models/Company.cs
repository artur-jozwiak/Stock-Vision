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
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public virtual OrderBook? OrderBook { get; set; }
        public int  OrderBookId { get; set; }
        public virtual Sector? Sector { get; set; }
        public int SectorId { get; set; }
        public virtual ICollection<StockIndex>? StockIndexes { get; set; }
        public virtual ICollection<IndexAssignment>? IndexAssignment { get; set; } = new List<IndexAssignment>();
    }
}
