﻿using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Interfaces;
using StockVision.Core.Models;
using StockVison.Scraper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderBooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ISheetScrapper _scrapper;
        public OrderBooksController(ISheetScrapper scrapper, IUnitOfWork unitOfWork)
        {   
            _scrapper = scrapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetOrderBook")]
        public async Task<OrderBook> GetOrderBook(string companyName)
        {
            companyName = "cdr";
            OrderBook orderBook = await _scrapper.GetOrderbook(companyName,0);

            return orderBook;
        }

        [HttpPost(Name = "SaveOrderBookInDb")]//Nie testowane
        public async Task SaveOrderBookInDb(string companyName, int skipLast)
        {
            OrderBook orderBook = await _scrapper.GetOrderbook(companyName, skipLast);
            await _unitOfWork.OrderBooks.Add(orderBook);
            await _unitOfWork.Save();
        }

        //[HttpGet(Name = "Test")]
        //public async  Task<List<decimal>> Test()
        //{
        //    List<decimal> result = new ();
        //    int[] ids = new int[] { 1, 80, 193, 199, 15, 303, 233, 297 };
        //    for (int i = 0; i < ids.Length; i++)
        //    {
        //        var company = await _unitOfWork.Companies.GetWithOrderBook(ids[i]);
        //        AskOrderBook? curentAskOrders = company.OrderBooks.OrderByDescending(o => o.LoadTime).Select(o => o.AskOrderBook).FirstOrDefault();
        //        decimal currentMaxAskPrice = curentAskOrders.Orders.OrderByDescending(o => o.Price).Select(o => o.Price).FirstOrDefault();
        //        BidOrderBook? curentBidOrders = company.OrderBooks.OrderByDescending(o => o.LoadTime).Select(o => o.BidOrderBook).FirstOrDefault();
        //        decimal currentMinBidPrice = curentBidOrders.Orders.OrderBy(o => o.Price).Select(o => o.Price).FirstOrDefault();

        //        decimal askRangeLimit = currentMaxAskPrice - (currentMaxAskPrice * 5 / 100);
        //        int currentAskOrdersVolume = curentAskOrders.Orders.Where(o => o.Price >= askRangeLimit).Sum(o => o.Volume);
        //        decimal bidRangeLimit = currentMinBidPrice + (currentMinBidPrice * 5 / 100);
        //        int currentBidOrdersVolume = curentBidOrders.Orders.Where(o => o.Price <= bidRangeLimit).Sum(o => o.Volume);

        //        //Last
        //        AskOrderBook? lastAskOrders = company.OrderBooks.OrderByDescending(o => o.LoadTime).Select(o => o.AskOrderBook).ElementAt(1);
        //        decimal lastMaxAskPrice = lastAskOrders.Orders.OrderByDescending(o => o.Price).Select(o => o.Price).FirstOrDefault();
        //        BidOrderBook? lastBidOrders = company.OrderBooks.OrderByDescending(o => o.LoadTime).Select(o => o.BidOrderBook).ElementAt(1);
        //        decimal lastMinBidPrice = lastBidOrders.Orders.OrderBy(o => o.Price).Select(o => o.Price).FirstOrDefault();

        //        askRangeLimit = lastMaxAskPrice - (lastMaxAskPrice * 5 / 100);
        //        int lastAskOrdersVolume = lastAskOrders.Orders.Where(o => o.Price >= askRangeLimit).Sum(o => o.Volume);
        //        bidRangeLimit = lastMinBidPrice + (lastMinBidPrice * 5 / 100);
        //        int lastBidOrdersVolume = lastBidOrders.Orders.Where(o => o.Price <= bidRangeLimit).Sum(o => o.Volume);

        //        decimal AskOrdersVolumeDifference = currentAskOrdersVolume - lastAskOrdersVolume;
        //        decimal BidOrdersVolumeDifference = currentBidOrdersVolume - lastBidOrdersVolume;
        //        decimal percentageAskOrdersVolumeDifference = AskOrdersVolumeDifference * 100 / lastAskOrdersVolume;
        //        decimal percentageBidOrdersVolumeDifference = BidOrdersVolumeDifference * 100 / lastBidOrdersVolume;
        //        //decimal[] result = new decimal[2] { percentageAskOrdersVolumeDifference, percentageBidOrdersVolumeDifference };
        //        //return result;
        //        result.Add(company.Id);
        //        result.Add(percentageAskOrdersVolumeDifference);
        //        result.Add(percentageBidOrdersVolumeDifference);
                
        //    }
        //    return result;
        //}
    }
}
