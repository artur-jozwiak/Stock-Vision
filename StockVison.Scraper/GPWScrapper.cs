using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockVison.Scraper
{
    public class GPWScrapper : IGPWScrapper
    {

        public async Task<IEnumerable<IEnumerable<string>>> GetListOfCompaniesFromGPW()
        {

            string url = $"https://stooq.pl/t/?i=523";

            using (var client = new HttpClient())
            {

                var html = await client.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode($"//table[@id='fth1']");
                var sheet = table.Descendants("tr")
                                 .Skip(1)
                                 //.SkipLast(skipLast)
                                 .Select(tr => tr.Descendants("td")
                                            .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                            .ToList());

                var result = table.Descendants("tr")
                                 .Skip(0)
                                 .Select(tr => tr.Descendants("td")
                                            .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                            .ToList());
                return result;
            }
        }

        public List<Company> MapResponseCompaniesList(IEnumerable<IEnumerable<string>> response)
        {
            List<Company> companies = new List<Company>();

            foreach (var companyRecord in response)
            {
                var tableRecord = companyRecord.ToArray();
                Company company = new Company
                {
                    Name = tableRecord[0],
                    Symbol = tableRecord[1],
                };
                companies.Add(company);
            }
            return companies;
        }

        public async Task<List<Company>> GetCompanies()
        {
            var response = await GetListOfCompaniesFromGPW();
            var companies = MapResponseCompaniesList(response);
            return companies;
        }

        public async Task GPW()
        {

            string url = $"https://stooq.pl/t/?i=523";

            using (var client = new HttpClient())
            {

                var response = await client.GetAsync("https://stooq.pl/t/?i=523");
                //  var html = await client.GetStringAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var xml = await response.Content.ReadAsStringAsync();
                    var doc = XDocument.Parse(xml);
                    var titles = from el in doc.Descendants("title")
                                 select el.Value;
                }
            }
        }
    }
}

