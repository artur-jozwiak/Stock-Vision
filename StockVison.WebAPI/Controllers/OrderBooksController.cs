using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Interfaces;
using StockVision.Core.Models;
using StockVison.Scraper;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderBooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ISheetScrapper _scrapper;
        public OrderBooksController(ISheetScrapper scrapper, IUnitOfWork unitOfWork)
        {   
            _scrapper = scrapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetOrderBook")]
        public async Task<OrderBook> GetOrderBook(string companyName, int skipLast)
        {
            companyName = "cdr";
            skipLast = 350;
            OrderBook orderBook = await _scrapper.GetOrderbook(companyName, skipLast);

            return orderBook;
        }

        [HttpPost(Name = "SaveOrderBookInDb")]//Nie testowane
        public async Task SaveOrderBookInDb(string companyName, int skipLast)
        {
            OrderBook orderBook = await _scrapper.GetOrderbook(companyName, skipLast);
            await _unitOfWork.OrderBooks.Add(orderBook);
            await _unitOfWork.Save();
        }
        //dodać wystawienie Orderbook z bazy po id firmy i dacie
    }
}
