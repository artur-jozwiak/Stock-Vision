using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Interfaces.Repositories
{
    public interface IOrderBookRepository : IRepository<OrderBook>
    {
        Task<OrderBook?> GetWithAskBidOrderBook(int id);
        Task<OrderBook?> GetFirstWithAskBidOrderBook();
    }
}
