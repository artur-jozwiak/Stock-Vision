using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<string>> GetBayOredersSheet()

        {
            scraper = new SheetScraper();
            return await scraper.GetBayOrderSheet();
        }
        

    }
}
