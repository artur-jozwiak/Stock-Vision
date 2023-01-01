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

        public async Task<Company?> GetWithOrderBook(int id)
        {
          return await  StockVisionContext.Companies.Where(c => c.Id == id)
                .Include(o => o.OrderBooks)
                    .ThenInclude(a => a.AskOrderBook)
                        .ThenInclude(o => o.Orders)
                .Include(o => o.OrderBooks)
                    .ThenInclude(b => b.BidOrderBook)
                        .ThenInclude(o => o.Orders)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetAllWithIndexesAndSectors()
        {
            return await StockVisionContext.Companies
                .Include(c => c.Sector)
                .Include(c => c.StockIndexes)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Company?> GetWithCompanies(int id)
        {
            return await StockVisionContext.Companies.Where(c => c.Id == id)
                .Include(c => c.Sector)
                .Include(c => c.StockIndexes)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }


        public async Task<Company?> GetByName(string name)
        {
            return await StockVisionContext.Companies.FirstOrDefaultAsync(s => s.Name == name);
        }


        public StockVisionContext StockVisionContext
        {
            get { return Context as StockVisionContext; }
        }
    }
}
