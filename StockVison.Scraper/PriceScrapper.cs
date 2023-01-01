using HtmlAgilityPack;
using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockVison.Scraper
{
    public class PriceScrapper : IPriceScrapper
    {
        public async Task<IEnumerable<IEnumerable<string>>> GetPrice()
        {

            string url = $"https://www.stockwatch.pl/notowania/";
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode($"//table[@id='mostRiceDiv']");
                var sheet = table.Descendants("tr")
                                 .Skip(1)
                                 .SkipLast(0)
                                 .Select(tr => tr.Descendants("td")
                                            .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                            .ToList());
                return sheet;
            }
        }
    }
}
