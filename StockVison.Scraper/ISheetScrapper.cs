using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVison.Scraper
{
    public interface ISheetScrapper
    {
        Task<OrderBook> GetOrderbook(string companySymbol, int skipLast);
        Task<IEnumerable<IEnumerable<string>>> GetSheet(string companySymbol, string orderBookType, int skipLast);
        ICollection<Order> MapResponseToOrderSheet(IEnumerable<IEnumerable<string>> sheet);
    }
}
