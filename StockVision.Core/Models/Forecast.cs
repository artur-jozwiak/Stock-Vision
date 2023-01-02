using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public virtual Company? Company { get; set; }
        public int? CompanyId { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public Recomendation? Recomendation { get; set; }
        public decimal? Result { get; set; }
        public decimal? AskOrderBookDifference { get; set; }
        public decimal? BidOrderBookDifference { get; set; }
    }
}
