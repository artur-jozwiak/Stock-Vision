using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockVision.BLL.Models;
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
            scraper = new SheetScraper();
            var buyOrdersSheet = await scraper.GetBuyOrderSheet(companyName, saleSheet);
            return  scraper.MapToOrderList(buyOrdersSheet);
        }




        [HttpPost(Name = "GetCompanySymbol")]

        public string GetCompanySymbol(string companySymbol)
        {
            return companySymbol;
        }


    }
}
