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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(StockVisionContext context) : base(context)
        {

        }

        public async Task<Company?> GetWithOrderBook(Guid id)
        {
          return await  StockVisionContext.Companies.Where(c => c.Id == id)
                .Include(o => o.OrderBook)
                    .ThenInclude(a => a.AskOrderBook)
                        .ThenInclude(o => o.Orders)
                .Include(o => o.OrderBook)
                    .ThenInclude(b => b.BidOrderBook)
                        .ThenInclude(o => o.Orders)
                .FirstOrDefaultAsync();
        }

        public StockVisionContext StockVisionContext
        {
            get { return Context as StockVisionContext; }
        }
    }
}
