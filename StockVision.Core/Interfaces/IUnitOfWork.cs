using StockVision.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IOrderBookRepository OrderBooks { get; }
        IStockIndexRepository StockIndexes { get; }
        ISectorRepository Sectors { get; }
        Task<int> Save();
    }
}
