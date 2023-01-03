//using StockVision.Core.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StockVision.Core.Services
//{
//    public class ForecastService
//    {
//        public Forecast CreateForecast(Company company)
//        {
//            //Current
//            AskOrderBook? curentAskOrders = company.OrderBooks.OrderByDescending(o => o.LoadTime).Select(o => o.AskOrderBook).FirstOrDefault();
//            decimal currentMaxAskPrice = curentAskOrders.Orders.OrderByDescending(o => o.Price).Select(o => o.Price).FirstOrDefault();
//            BidOrderBook? curentBidOrders = company.OrderBooks.OrderByDescending(o => o.LoadTime).Select(o => o.BidOrderBook).FirstOrDefault();
//            decimal currentMinBidPrice = curentBidOrders.Orders.OrderBy(o => o.Price).Select(o => o.Price).FirstOrDefault();

//            decimal askRangeLimit = CalculateAskRangeLimit(currentMaxAskPrice);
//            int currentAskOrdersVolume = curentAskOrders.Orders.Where(o => o.Price >= askRangeLimit).Sum(o => o.Volume);
//            decimal bidRangeLimit = CalculateBidRangeLimit(currentMinBidPrice);
//            int currentBidOrdersVolume = curentBidOrders.Orders.Where(o => o.Price <= bidRangeLimit).Sum(o => o.Volume);

//            //Last
//            AskOrderBook? lastAskOrders = company.OrderBooks.OrderByDescending(o => o.LoadTime).Select(o => o.AskOrderBook).ElementAt(1);
//            decimal lastMaxAskPrice = lastAskOrders.Orders.OrderByDescending(o => o.Price).Select(o => o.Price).FirstOrDefault();
//            BidOrderBook? lastBidOrders = company.OrderBooks.OrderByDescending(o => o.LoadTime).Select(o => o.BidOrderBook).ElementAt(1);
//            decimal lastMinBidPrice = lastBidOrders.Orders.OrderBy(o => o.Price).Select(o => o.Price).FirstOrDefault();

//            askRangeLimit = CalculateAskRangeLimit(lastMaxAskPrice);
//            int lastAskOrdersVolume = lastAskOrders.Orders.Where(o => o.Price >= askRangeLimit).Sum(o => o.Volume);
//            bidRangeLimit = CalculateBidRangeLimit(lastMinBidPrice);
//            int lastBidOrdersVolume = lastBidOrders.Orders.Where(o => o.Price <= bidRangeLimit).Sum(o => o.Volume);

//            decimal AskOrdersVolumeDifference = currentAskOrdersVolume - lastAskOrdersVolume;
//            decimal BidOrdersVolumeDifference = currentBidOrdersVolume - lastBidOrdersVolume;
//            decimal percentageAskOrdersVolumeDifference = AskOrdersVolumeDifference * 100 / lastAskOrdersVolume;
//            decimal percentageBidOrdersVolumeDifference = BidOrdersVolumeDifference * 100 / lastBidOrdersVolume;
//        }

//        public decimal CalculatePercentageDiverenceBetweenOrdebooks(ICollection<Order> orders)
//        {


//        }

//        public int CaculateVolume(ICollection<Order> orders)
//        {

//        }

//        public ICollection<Order> GetOrdersFromAskOrderBook(OrderBook orderBook)
//        {

//        }
//        public ICollection<Order> GetOrdersFromBidOrderBook(OrderBook orderBook)
//        {
//            var bidOrderbook
//        }
//        public decimal CalculateAskRangeLimit(decimal price)
//        {
//            int percentageRange = 5;
//            return price - (price * 5 / 100);

//        }
//        public decimal CalculateBidRangeLimit(decimal price)
//        {
//            int percentageRange = 5;
//            return price + (price * 5 / 100);
//        }
//    }
//}
