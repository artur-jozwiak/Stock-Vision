using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Models;
using StockVison.Scraper;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BayOrdersSheetController : ControllerBase
    {

        private ISheetScrapper _scrapper;
        public BayOrdersSheetController(ISheetScrapper scrapper)
        {
            _scrapper = scrapper;
        }

        [HttpGet(Name = "GetOrderBook")]
        public async Task<FullOrderBook> GetOrderBook(string companyName, int skipLast)
        {
            companyName = "cdr";
            return await _scrapper.GetOrderbook(companyName, skipLast);
        }

        //[HttpGet(Name = "GetBuyOredersSheet")]

        //public async Task<ICollection<Order>> GetBuyOredersSheet(string companySymbol, string orderBookType, int skipLast)
        //{
        //    orderBookType = "bid";
        //    companySymbol = "cdr";
        //    skipLast = 300;

        //    var buyOrdersSheet = await _scrapper.GetSheet(companySymbol, orderBookType, skipLast);
        //    return _scrapper.MapResponseToOrderSheet(buyOrdersSheet);
        //}

     
    }
}
