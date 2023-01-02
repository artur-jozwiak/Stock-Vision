using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Interfaces;
using StockVision.Core.Models;
using StockVison.Scraper;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISheetScrapper _scrapper;

        public CompaniesController(IUnitOfWork unitOfWork, ISheetScrapper srapper)
        {
            _unitOfWork = unitOfWork;
            _scrapper = srapper;
        }

        [HttpGet(Name = "GetCompanies")]
        public async Task<IEnumerable<Company>> GetSectors()
        {
            var companies = await _unitOfWork.Companies.GetAllWithIndexesAndSectors();
            //var sectorsWithoutDuplicates = sectors.DistinctBy(s => s.Name);
            return companies;
        }

        [HttpPost(Name = "LoadOrderBookToCompany")]
        public  async Task LoadOrderBookToCompany(int id)
        {
           var company = await _unitOfWork.Companies.GetWithOrderBook(id);
           var orderBook = await _scrapper.GetOrderbook(company.Symbol, 0);
           await _unitOfWork.OrderBooks.Add(orderBook);
            await _unitOfWork.Save();

            company.OrderBooks.Add(orderBook);
           _unitOfWork.Companies.Update(company);
           await _unitOfWork.Save();
        }
    }
}
