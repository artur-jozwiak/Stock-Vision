using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public virtual ICollection<Forecast>? Forecasts  { get; set; }
        public decimal? Effectiveness { get; set; }
    }
}
