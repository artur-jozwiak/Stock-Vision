using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Company>? Companies { get; set; }
    }
}
