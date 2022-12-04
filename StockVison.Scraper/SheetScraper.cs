using StockVision.BLL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockVison.Scraper
{
    public class SheetScraper
    {
        //public async  Task<IEnumerable<List<string>>> GetBayOrderSheet()
        public async Task<IEnumerable<string>> GetBayOrderSheet()

        {
            string url = "https://gragieldowa.pl/spolka_arkusz_zl/spolka/cdr";
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode("//table[@id='arkusz_left']");
                var a = table.Descendants("tr")
                            //.Skip(2)
                            .Select(tr => tr.Descendants("td")
                                            .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                            .ToList());
                //.ToList();
               // var secondFiveItems = myList.Skip(5).Take(5);
                return a.Skip(1).First(); 
            }
            return null;
        }

       // public async Task<IEnumerable<BuyOrderSheet>> GetBayOrderSheet()
    }
}

