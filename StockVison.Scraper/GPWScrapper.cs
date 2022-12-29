


using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using StockVision.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using System.Xml.Linq;

namespace StockVison.Scraper
{
    public class GPWScrapper : IGPWScrapper
    {
        //private const string BaseUrl = $"https://stooq.pl/t/?i=523";
        private const string BaseUrl = $"https://stooq.pl";

        // private const string BaseUrl = $"https://gpw.pl/";


        public async Task<IEnumerable<IEnumerable<string>>> GetListOfCompaniesFromGPW()
        {

             string url = $"https://stooq.pl";

            // string url = $"https://stooq.pl/t/?i=523";
            // string url = $"https://www.gpw.pl/spolki";


            using (var client = new HttpClient())
            {

                var html = await client.GetStringAsync(url);

                var doc = new HtmlAgilityPack.HtmlDocument();
                //

                //
                doc.LoadHtml(html);

               var table = doc.DocumentNode.QuerySelector("table");

                
                //var table = doc.DocumentNode.SelectSingleNode("aqp_6");
      

                // var table = doc.GetElementbyId("fth1");


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
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(@"<html><body><p><table id=""tb1""><tr><th>hello</th></tr><tr><td>world</td></tr></table></body></html>");
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            {
                Console.WriteLine("Found: " + table.Id);
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    Console.WriteLine("row");
                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        Console.WriteLine("cell: " + cell.InnerText);
                    }
                }
            }
            var web = new HtmlWeb();
            var document = web.Load(BaseUrl);

            var tableRows = document.GetElementbyId("tb1");


            // var tableRows = document.QuerySelectorAll("fth1");
            //foreach(var row in tableRows)
            //{

            //}
        }
    }
}

