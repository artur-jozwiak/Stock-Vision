using StockVision.Core.Interfaces;
using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Service.Interfaces
{
    public interface IGPWCompositionReader
    {
        string[] ReadLinesFromTxtFile();
        List<Company> GetCompaniesFromTxtFile(string[] data);
        List<Company> MapDataFromFileToCompaniesList(string[] data);
        ICollection<StockIndex> GetIndexesFromLine(string line);
        void AddCompaniesToDb(IEnumerable<Company> companies);

    }
}
