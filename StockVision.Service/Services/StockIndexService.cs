using StockVision.Core.Models;
using StockVision.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Service.Services
{
    public class StockIndexService : IStockIndexService
    {
        const string _baseUrl = "https://localhost:7015/StockIndexes";

        public async Task<IEnumerable<StockIndex>> GetIndexesFromAPI()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var stockIndex = await response.Content.ReadFromJsonAsync<IEnumerable<StockIndex>>();
            return stockIndex;
        }
    }
}
