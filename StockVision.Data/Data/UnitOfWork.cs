using StockVision.Core.Interfaces;
using StockVision.Core.Interfaces.Repositories;
using StockVision.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockVisionContext _context;
        public ICompanyRepository Companies { get; private set; }
        public IOrderBookRepository OrderBooks { get; private set; }
        public IStockIndexRepository StockIndexes { get; private set; }
        public ISectorRepository Sectors { get; private set; }
        public IForecastRepository Forecasts { get; private set; }
        public IWalletRepository Wallets { get; private set; }

        public UnitOfWork(StockVisionContext context)
        {
            _context = context;
            Companies = new CompanyRepository(_context);
            OrderBooks = new OrderBookRepository(_context);
            StockIndexes = new StockIndexRepository(_context);
            Sectors = new SectorRepository(_context);
            Forecasts = new ForecastRepository(_context);
            Wallets = new WalletRepository(_context);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
