using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockVision.Service.Interfaces
{
    public interface IOrderBookService
    {
        Task<List<Order>> GetAskOrderBook();
        Task<FullOrderBook> GetOrderBook();

    }
}
