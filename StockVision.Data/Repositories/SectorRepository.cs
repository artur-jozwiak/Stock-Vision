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
    public class SectorRepository : Repository<Sector>, ISectorRepository
    {
        public SectorRepository(StockVisionContext context) : base(context)
        {

        }

        public async Task<Sector?> GetByName(string name)
        {
            return await StockVisionContext.Sectors.FirstOrDefaultAsync(s => s.Name == name);
        }

        public StockVisionContext StockVisionContext
        {
            get { return Context as StockVisionContext; }
        }
    }
}
