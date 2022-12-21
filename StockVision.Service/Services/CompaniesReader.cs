using StockVision.Core.Interfaces;
using StockVision.Core.Interfaces.Repositories;
using StockVision.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Service.Services
{
    public class CompaniesReader
    {

        private readonly IUnitOfWork _unitOfWork;
        public CompaniesReader(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<string> ReadLinesFromCompaniesTxtFile()
        {
            var lines = File.ReadAllLines("G:\\Moje programy\\Stock Vision\\StockVision\\Companies.txt").ToList();
            return lines;
        }

        public string[] ClearData(List<string> lines)
        {
            List<string> output = new List<string>();
            char[] delimiters = { '(', ')', '|', '\t', };

            foreach (var element in lines)
            {
                var result = element.Split(delimiters);
                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i] != ""
                        && result[i] != "Główny Rynek "
                        && decimal.TryParse(result[i], out _) == false
                        //&& Regex.IsMatch(result[i], @"^\d") == false 
                        && result[i].StartsWith('-') == false
                        && result[i].StartsWith('+') == false
                        && result[i].StartsWith('0') == false)
                    {
                        output.Add(result[i].Replace("SPÓŁKA AKCYJNA", string.Empty));
                    }
                }
            }
            return output.ToArray();
        }
        public List<Company> GetCompaniesFromTxtFile(string[] data)
        {
            var companies = new List<Company>();
            for (int i = 0; i <= data.Count(); i = +3)
            {
                Company company = new Company()
                {
                    Name = data[i],
                    Symbol = data[i + 1],
                };
                companies.Add(company);
            }
            return companies;
        }
        /// <summary>
        /// ///////////////
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        public List<Company> MapDataFromFileToCompaniesList( string[] data)
        {   
            var companiesList = new List<Company>();
            for (int i = 0; i <= data.Count()/4; i++)
            {
                Company company = new Company()
                {
                    Name = data[i],
                    Symbol = data[i + 1],
                    StockIndexes = GetIndexesFromLine(data[i + 2]),
                    Sector = new Sector()
                    {
                        Name = data[3]
                    }
                };
                companiesList.Add(company);
            }
            return companiesList;
        }

        public ICollection<StockIndex> GetIndexesFromLine(string line)
        {
            var indexes = new List<StockIndex>();
            var indexesNames = line.Split(',');
            foreach(var name in indexesNames)
            {
                var index = new StockIndex()
                {
                    Name = name,
                };
                indexes.Add(index);
            }
            return indexes;
        }

       public async void AddCompaniesToDb(IEnumerable<Company> companies)
        {
           await _unitOfWork.Companies.AddRange(companies);
           await _unitOfWork.Save();
        }
    }
}
