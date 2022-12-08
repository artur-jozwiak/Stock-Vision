using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Models;
using StockVison.Scraper;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderBookController : ControllerBase
    {
        private ISheetScrapper _scrapper;
        public OrderBookController(ISheetScrapper scrapper)
        {
            _scrapper = scrapper;
        }

        [HttpGet(Name = "GetOrderBook")]
        public async Task<FullOrderBook> GetOrderBook(string companyName, int skipLast)
        {
            companyName = "cdr";
            return await _scrapper.GetOrderbook(companyName, skipLast);
        }
    }
}
