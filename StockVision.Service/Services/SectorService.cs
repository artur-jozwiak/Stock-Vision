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
    public class SectorService : ISectorService
    {
        const string _baseUrl = "https://localhost:7015/Sectors";

        public async Task<IEnumerable<Sector>> GetSectorsFromAPI()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var sector = await response.Content.ReadFromJsonAsync<IEnumerable<Sector>>();
            return sector;
        }
    }
}
