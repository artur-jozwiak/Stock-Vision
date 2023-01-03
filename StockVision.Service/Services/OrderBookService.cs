using StockVision.Core.Interfaces;
using StockVision.Core.Models;
using StockVision.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockVision.Service.Services
{
    public class OrderbookService : IOrderBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderbookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        const string _baseUrl = "https://localhost:7015/OrderBooks?companyName=cdr";
        private string _companySymbolEndpoint = string.Empty;

        public async Task<OrderBook> GetOrderBookFromAPI()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var orderBook = await response.Content.ReadFromJsonAsync<OrderBook>();
            return orderBook;
        }

        //Usunąć wraz z konstruktorem i Uow 
        // Pobieranie z API I Z db ma sie odbywac w projekcie web api
        public async Task<OrderBook?> GetOrderBookFromDb()
        {
            OrderBook orderBook = await _unitOfWork.OrderBooks.GetFirstWithAskBidOrderBook();
            return orderBook;
        }
       
    }
}
