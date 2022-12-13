using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Service.Services
{
    public  class CompanyDataReader
    {
        public List<string> ReadLinesFromCompaniesTxtFile()
        {
            return    File.ReadAllLines("G:\\Moje programy\\Stock Vision\\StockVision\\test.txt").ToList();
        }
    }
}
