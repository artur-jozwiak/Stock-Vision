
using HtmlAgilityPack;
using Microsoft.VisualBasic;
using StockVision.Core.Models;
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
    public class SheetScraper : ISheetScrapper
    {
        private static readonly Regex whiteSpace = new Regex(@"\s+");
        private static string askOrderBook = "arkusz_left";
        private static string bidOrderBook = "arkusz_right";
        private static string[] orderBookType = new string[2] { askOrderBook, bidOrderBook };

        public async Task<OrderBook> GetOrderbook(string companySymbol, int skipLast)
        {
            OrderBook orderBook = new OrderBook();

            var askSheet = await GetSheet(companySymbol, "ask", skipLast);
            var askOrders =  MapResponseToOrderSheet(askSheet);

            var bidSheet = await GetSheet(companySymbol, "bid", skipLast);
            var bidOrders = MapResponseToOrderSheet(bidSheet);
            
            orderBook.AskOrderBook.Orders = askOrders;
            orderBook.BidOrderBook.Orders = bidOrders;
            return orderBook;
        }

        public ICollection<Order> MapResponseToOrderSheet(IEnumerable<IEnumerable<string>> sheet)
        {
            ICollection<Order> orderSheet = new List<Order>();
            sheet = sheet.SkipLast(1).Skip(1);

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
                orderSheet.Add(order);
            }
            return orderSheet;
        }

        public async Task<IEnumerable<IEnumerable<string>>> GetSheet(string companySymbol, string orderBookType,int skipLast)
        {
            string sheetType = string.Empty;
            if (orderBookType == "ask")
            {
                sheetType = "arkusz_left";
            }

            if (orderBookType == "bid")
            {
                sheetType = "arkusz_right";
            }

            string url = $"https://gragieldowa.pl/spolka_arkusz_zl/spolka/{companySymbol}";
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var table = doc.DocumentNode.SelectSingleNode($"//table[@id='{sheetType}']");
                var sheet = table.Descendants("tr")
                                 .Skip(1)
                                 .SkipLast(skipLast)
                                 .Select(tr => tr.Descendants("td")
                                            .Select(td => WebUtility.HtmlDecode(td.InnerText))
                                            .ToList());
                return sheet;
            }
        }
       
    }
}

