using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company?> GetWithOrderBook(int id);
        Task<Company?> GetByName(string name);
        Task<IEnumerable<Company>> GetAllWithIndexesAndSectors();
        Task<Company?> GetWithCompanies(int id);
    }
}
