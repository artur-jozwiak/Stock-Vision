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
       // private readonly HttpClient _httpClient;
        const string _baseUrl = "https://localhost:7015/BayOrdersSheet?companyName=cdr";
        private string _companySymbolEndpoint = string.Empty;

        public OrderbookService(/*HttpClient httpClient*/)
        {
           // _httpClient = httpClient;
        }

        //public async Task<ICollection<Order>> GetOrderBook()//Ma zwracać cały arkusz
        //{

        //}

        public async Task<List<Order>> GetAskOrderBook()//Ma zwracać ask
        {
            //ConfigureHttpClient();
            HttpClient httpClient = new HttpClient();
            //var response = await httpClient.GetAsync(_companySymbolEndpoint);
            var response = await httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();

            var order = await response.Content.ReadFromJsonAsync<List<Order>>();
            //using var stream = await response.Content.ReadAsStreamAsync();

            // var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleApiResponse>();

            //var order = await JsonSerializer.DeserializeAsync<OrderBook>(stream);

            return order;
        }

        //public void ConfigureHttpClient()
        //{
        //    _httpClient.BaseAddress = new Uri(_baseUrl);
        //}
    }
}
