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
        //public async  Task<IEnumerable<List<string>>> GetBayOredersSheet()
        public async Task<ICollection<Order>> GetBayOredersSheet()

        {
            scraper = new SheetScraper();
            var buyOrdersSheet = await scraper.GetBayOrderSheet();
           return  scraper.MapToBuyOrderSheet(buyOrdersSheet);
        }
        

    }
}
