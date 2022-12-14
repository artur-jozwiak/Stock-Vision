using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Program
{
    private static void Main(string[] args)
    {
        var list = ReadLinesFromCompaniesTxtFile();
        var clearList = ClearList(list);
        List<string> ReadLinesFromCompaniesTxtFile()
        {
            var lines = File.ReadAllLines("G:\\Moje programy\\Stock Vision\\StockVision\\Companies.txt").ToList();
            return lines;
        }

        List<string> ClearList(List<string> lines)
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
                        output.Add(result[i]);
                    }
                }
            }

            foreach (var line in output)
            {
                Console.WriteLine(line);
            }

            return output;
        }
    }
}