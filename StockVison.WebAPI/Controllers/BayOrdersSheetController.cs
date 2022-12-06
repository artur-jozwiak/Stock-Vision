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
        private SheetScraper scraper;


        [HttpGet(Name = "GetBayOredersSheet")]

        public async Task<ICollection<Order>> GetBuyOredersSheet(string companyName, bool saleSheet)
        {
           // saleSheet = true;
            scraper = new SheetScraper();
            var buyOrdersSheet = await scraper.GetBuyOrderSheet(companyName, saleSheet);
            return  scraper.MapToOrderList(buyOrdersSheet);
        }
    }
}
