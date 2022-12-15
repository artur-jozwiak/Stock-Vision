using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Models
{
    public class IndexAssignment
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int StockIndexId { get; set; }
        public virtual StockIndex StockIndex { get; set; }
    }
}
