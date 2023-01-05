using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Models;
using StockVison.Scraper;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceScrapper _priceScrapper;

        public PriceController(IPriceScrapper priceScrapper)
        {
            _priceScrapper = priceScrapper;
        }

        [HttpGet]
        public async Task GetPrices()
        {
          await  _priceScrapper.GetPrice();
        }
    }
}
