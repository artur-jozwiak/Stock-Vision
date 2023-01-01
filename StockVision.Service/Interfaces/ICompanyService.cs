using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Service.Interfaces
{
    public interface ICompanyService
    {
         Task<IEnumerable<Company>> GetCompaniesFromApi();
    }
}
