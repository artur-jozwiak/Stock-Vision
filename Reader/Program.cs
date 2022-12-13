using System;


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

        List<string> ClearList(List<string> input)
        {
            List<string> output = new List<string>();
            char[] delimiters = { '(', ')', '|', };

            foreach(var element in input)
            {
             var result = element.Split(delimiters);
                output.Add(result[0]);
                output.Add(result[1]);
                output.Add(result[2]);

            }
            return output;
        }
    }
}