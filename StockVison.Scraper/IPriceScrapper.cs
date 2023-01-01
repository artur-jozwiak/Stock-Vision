using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVison.Scraper
{
    public interface IPriceScrapper
    {
        Task<IEnumerable<IEnumerable<string>>> GetPrice();
    }
}
