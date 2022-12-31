using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Interfaces.Repositories
{
    public interface ISectorRepository : IRepository<Sector>
    {
   
        Task<Sector?> GetByName(string name);
        Task<IEnumerable<Sector>> GetAllWithCompanies();
        Task<Sector?> GetWithCompanies(int id);
    }
}
