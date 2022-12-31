using StockVision.Core.Interfaces;
using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Core.Interfaces
{
    public interface IGPWCompositionReader
    {
        string[] ReadLinesFromTxtFile();
        Task GetCompaniesIndexesSectorsFromTxtFile(string[] data);
    }
}
