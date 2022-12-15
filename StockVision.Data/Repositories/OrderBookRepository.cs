using Microsoft.EntityFrameworkCore;
using StockVision.Core.Interfaces.Repositories;
using StockVision.Core.Models;
using StockVision.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Data.Repositories
{
    public class OrderBookRepository : Repository<OrderBook>, IOrderBookRepository
    {
        public OrderBookRepository(StockVisionContext context) : base(context)
        {

        }

        public async Task<OrderBook?> GetWithAskBidOrderBook(int id)
        {
            return await StockVisionContext.OrderBooks.Where(o => o.Id == id)
                .Include(a => a.AskOrderBook)
                    .ThenInclude(o => o.Orders)
                .Include(b => b.BidOrderBook)
                    .ThenInclude(o => o.Orders)
                .FirstOrDefaultAsync();
        }

        public async Task<OrderBook?> GetFirstWithAskBidOrderBook()
        {
            return await StockVisionContext.OrderBooks
                .Include(a => a.AskOrderBook)
                    .ThenInclude(o => o.Orders)
                .Include(b => b.BidOrderBook)
                    .ThenInclude(o => o.Orders)
                .FirstOrDefaultAsync();
        }

        public StockVisionContext StockVisionContext
        {
            get { return Context as StockVisionContext; }
        }
    }
}
