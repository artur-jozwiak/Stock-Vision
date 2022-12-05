using Microsoft.VisualBasic;
using StockVision.BLL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockVison.Scraper
{
    public class SheetScraper
    {
        private static readonly Regex whiteSpace = new Regex(@"\s+");
        //public async  Task<IEnumerable<List<string>>> GetBayOrderSheet()
        public async Task<IEnumerable<IEnumerable<string>>> GetBayOrderSheet()

        {
            string url = "https://gragieldowa.pl/spolka_arkusz_zl/spolka/cdr";
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode("//table[@id='arkusz_left']");
                var sheet = table.Descendants("tr")
                            .Skip(1)
                            .Select(tr => tr.Descendants("td")
                                            .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                            .ToList());
                return sheet; 
            }
            return null;
        }

        public ICollection<Order> MapToBuyOrderSheet(IEnumerable<IEnumerable<string>> sheet)
        {
            // BuyOrderSheet buyOrderSheet = new BuyOrderSheet();
            ICollection<Order> buyOrderSheet = new List<Order>();
            Order order = new Order();
            foreach (var sheetItem in sheet.SkipLast(1))
            {
               var sheetItemArray = sheetItem.ToArray();

                order.Price = decimal.Parse(sheetItemArray[0]);
                order.Volume = Convert.ToInt32(whiteSpace.Replace(sheetItemArray[1],""));
                order.OrdersValue = decimal.Parse(sheetItemArray[2]);
                order.Quantity = Convert.ToInt32(whiteSpace.Replace(sheetItemArray[3], ""));
                order.SharePercentage = decimal.Parse(whiteSpace.Replace(sheetItemArray[4].Replace("%",""),""));

                buyOrderSheet.Add(order);
            }
            return buyOrderSheet;
         }
    }
}

