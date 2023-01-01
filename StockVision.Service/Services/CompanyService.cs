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
    public class CompanyService : ICompanyService
    {
        const string _baseUrl = "https://localhost:7015/Companies";

        public async Task<IEnumerable<Company>> GetCompaniesFromApi()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var companies = await response.Content.ReadFromJsonAsync<IEnumerable<Company>>();
            return companies;
        }
    }
}
