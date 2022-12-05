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

        public async Task<IEnumerable<IEnumerable<string>>> GetBuyOrderSheet(string companySymbol, bool saleSheet)
        {
            string sheetType = String.Empty;

            if(saleSheet)
            {
                sheetType = "arkusz_right";
            }
            else
            {
                sheetType = "arkusz_left";
            }

            string url = $"https://gragieldowa.pl/spolka_arkusz_zl/spolka/{companySymbol}";
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode($"//table[@id='{sheetType}']");
                var sheet = table.Descendants("tr")
                                 .Skip(1)
                                 .Select(tr => tr.Descendants("td")
                                            .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                            .ToList());
                return sheet;
            }
        }

        public ICollection<Order> MapToOrderList(IEnumerable<IEnumerable<string>> sheet)
        {
            ICollection<Order> buyOrderSheet = new List<Order>();
            sheet = sheet.SkipLast(1);

            foreach (var sheetItem in sheet)
            {
                var sheetItemArray = sheetItem.ToArray();
                Order order = new Order
                {
                    Price = decimal.Parse(sheetItemArray[0]),
                    Volume = Convert.ToInt32(whiteSpace.Replace(sheetItemArray[1], "")),
                    OrdersValue = decimal.Parse(sheetItemArray[2]),
                    Quantity = Convert.ToInt32(whiteSpace.Replace(sheetItemArray[3], "")),
                    SharePercentage = decimal.Parse(whiteSpace.Replace(sheetItemArray[4].Replace("%", ""), ""))
                };
                buyOrderSheet.Add(order);
            }
            return buyOrderSheet;
        }
    }
}

