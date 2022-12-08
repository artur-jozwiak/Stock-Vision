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
        const string _baseUrl = "https://localhost:7015/OrderBook?companyName=cdr";
        private string _companySymbolEndpoint = string.Empty;

        public async Task<OrderBook> GetOrderBookAPI()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var orderBook = await response.Content.ReadFromJsonAsync<OrderBook>();
            return orderBook;
        }

        public async Task<OrderBook?> GetOrderBookDb()
        {
            OrderBook orderBook = await _unitOfWork.OrderBooks.GetFirstWithAskBidOrderBook();
            return orderBook;
        }

        public async Task<List<Order>> GetAskOrderBook()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadFromJsonAsync<List<Order>>();
            return order;
        }

       
    }
}
