using StockVision.Core.Models;

namespace StockVison.Scraper
{
    public interface IGPWScrapper
    {
        Task<IEnumerable<IEnumerable<string>>> GetListOfCompaniesFromGPW();
        List<Company> MapResponseCompaniesList(IEnumerable<IEnumerable<string>> response);
        Task<List<Company>> GetCompanies();

        Task GPW();
    }
}