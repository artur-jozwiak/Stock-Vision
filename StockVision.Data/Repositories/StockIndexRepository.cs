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
    public class StockIndexRepository : Repository<StockIndex>, IStockIndexRepository
    {
        public StockIndexRepository(StockVisionContext context) : base(context)
        {

        }

        public async Task<StockIndex?> GetByName(string name)
        {
            return await StockVisionContext.StockIndexes.FirstOrDefaultAsync(i => i.Name == name);
        }

        public async Task<IEnumerable<StockIndex>> GetAllWithCompanies()
        {
            return await StockVisionContext.StockIndexes
                .Include(i => i.Companies)
                .ToListAsync();
        }

        public async Task<StockIndex?> GetWithCompanies(int id)
        {
            return await StockVisionContext.StockIndexes.Where(i => i.Id == id)
                .Include(i => i.Companies)
                .FirstOrDefaultAsync();
        }

        public StockVisionContext StockVisionContext
        {
            get { return Context as StockVisionContext; }
        }
    }
}
