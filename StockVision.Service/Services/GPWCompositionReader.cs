using StockVision.Core.Interfaces;
using StockVision.Core.Interfaces.Repositories;
using StockVision.Core.Models;
using StockVision.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVision.Service.Services
{
    public class GPWCompositionReader : IGPWCompositionReader
    {

        private readonly IUnitOfWork _unitOfWork;
        public GPWCompositionReader(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string[] ReadLinesFromTxtFile()
        {
            var lines = File.ReadAllLines("G:\\Moje programy\\Stock Vision\\StockVision\\Companies.txt").ToList();

            List<string> output = new List<string>();
            char[] delimiters = { '(', ')', '|', '\t' };

            foreach (var element in lines)
            {
                var result = element.Split(delimiters);
                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i] != ""
                        && result[i] != "Główny Rynek "
                        && decimal.TryParse(result[i], out _) == false
                        && result[i].StartsWith('-') == false
                        && result[i].StartsWith('+') == false
                        && result[i].StartsWith("0,") == false)
                    {
                        output.Add(result[i].Replace("SPÓŁKA AKCYJNA", string.Empty));
                    }
                }
            }
            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
            return output.ToArray();
        }

        public async Task GetCompaniesIndexesSectorsFromTxtFile(string[] data)
        {
            int i = 0;
            while (i <= data.Length - 4)
            {
                Company company = new Company()
                {
                    Name = data[i],
                    Symbol = data[i + 1],
                    //OrderBook =  null
                };
                await _unitOfWork.Companies.Add(company);
                await _unitOfWork.Save();
                List<StockIndex?> stockIndexes = new List<StockIndex?>();
                string indexesLines = null;
                List<string> indexesNames = new List<string>();

                if (data[i + 2].StartsWith(" WIG") || data[i + 2].StartsWith(" INNOVATOR"))
                {
                    indexesLines = data[i + 2];
                     indexesNames = indexesLines.Split('\u002C').ToList();

                    foreach (var name in indexesNames)
                    {
                        StockIndex stockIndex = new StockIndex()
                        {
                            Name = name,
                        };
                        stockIndexes.Add(stockIndex);
                        if (await _unitOfWork.StockIndexes.GetByName(stockIndex.Name) == null)
                        {
                            await _unitOfWork.StockIndexes.Add(stockIndex);
                            await _unitOfWork.Save();
                        }
                    }
                }

                int placeOfSector = 0;
                if (data[i + 2].StartsWith(" WIG") || data[i + 2].StartsWith(" INNOVATOR"))
                {
                    placeOfSector = 3;
                }
                else
                {
                    placeOfSector = 2;
                }
                Sector sector = new Sector()
                {
                    Name = data[i + placeOfSector]
                };

                if( await _unitOfWork.Sectors.GetByName(sector.Name) == null)
                {
                    await _unitOfWork.Sectors.Add(sector);
                    await _unitOfWork.Save();
                }

                //////////////////

                company = await _unitOfWork.Companies.GetByName(company.Name);
                List<StockIndex?> companyStockIndexes = new List<StockIndex?>();
                foreach (string indexName in indexesNames)
                {
                    var stockIndex = await _unitOfWork.StockIndexes.GetByName(indexName);
                    stockIndexes.Add(stockIndex);
                }

                company.StockIndexes = stockIndexes;
                company.Sector = sector;
                _unitOfWork.Companies.Update(company);
                await _unitOfWork.Save();

                ///////////////////
                
                foreach(var stockIndex in stockIndexes)
                {
                    stockIndex.Companies.Add(company);
                    _unitOfWork.StockIndexes.Update(stockIndex);
                    await _unitOfWork.Save();
                }

                ///////////////////

                sector = await _unitOfWork.Sectors.GetByName(sector.Name);
                sector.Companies.Add(company);
                _unitOfWork.Sectors.Update(sector);
                await _unitOfWork.Save();

                if (data[i + 2].StartsWith(" WIG") || data[i + 2].StartsWith(" INNOVATOR"))
                {
                    i += 4;
                }
                else
                {
                    i += 3;
                }
            }
        }

        public List<Company> GetCompaniesFromTxtFile(string[] data)
        {
            var companies = new List<Company>();
            int i = 0;
            while(i <= data.Length - 4)
            {
                Company company = new Company()
                {
                    Name = data[i],
                    Symbol = data[i + 1],
                };
                companies.Add(company);

                if (data[i + 2].StartsWith(" WIG") || data[i + 2].StartsWith(" INNOVATOR"))
                {
                    i += 4;
                }
                else
                {
                    i += 3;
                }
            }

            return companies;
        }


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
