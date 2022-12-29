using StockVision.Core.Interfaces;
using StockVision.Core.Interfaces.Repositories;
using StockVision.Core.Models;
using StockVision.Data.Data;
using StockVision.Service.Services;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Program
{
    
  
    private static void Main(string[] args)
    {
        StockVisionContext context = new();
        UnitOfWork uow = new UnitOfWork(context);
        GPWCompositionReader companiesReader = new(uow);
        var list = ReadLinesFromCompaniesTxtFile();
        var clearList = ClearListOfCompaniesWithIndexesAndSectors(list);
       var companies = GetCompaniesFromTxtFile(clearList);
        //var companies = MapDataFromFileToCompaniesList(clearList).AsEnumerable();
        //companiesReader.AddCompaniesToDb(companies);

        List<string> ReadLinesFromCompaniesTxtFile()
        {
            var lines = File.ReadAllLines("G:\\Moje programy\\Stock Vision\\StockVision\\Companies.txt").ToList();
            return lines;
        }

        string[] ClearListOfCompaniesWithIndexesAndSectors(List<string> lines)
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

            foreach (var line in output)
            {
                Console.WriteLine(line);
            }

            return output.ToArray();
        }

         List<Company> GetCompaniesFromTxtFile(string[] data)
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
        /////////////
        List<Company> MapDataFromFileToCompaniesList(string[] data)
        {
            var companiesList = new List<Company>();
            for (int i = 0; i <= data.Count() / 4; i++)
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

         ICollection<StockIndex> GetIndexesFromLine(string line)
        {
            var indexes = new List<StockIndex>();
            var indexesNames = line.Split(',');
            foreach (var name in indexesNames)
            {
                var index = new StockIndex()
                {
                    Name = name,
                };
                indexes.Add(index);
            }
            return indexes;
        }
    }
}