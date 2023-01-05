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

        [HttpGet]
        public async Task<IEnumerable<Company>> GetSectors()
        {
            var companies = await _unitOfWork.Companies.GetAllWithIndexesAndSectors();
            //var sectorsWithoutDuplicates = sectors.DistinctBy(s => s.Name);
            return companies;
        }

        // PATCH api/Companies/id
        [HttpPatch("{id}")]
        public async Task LoadOrderBookToCompany(int id)
        {
            var company = await _unitOfWork.Companies.GetWithOrderBook(id);
            var orderBook = await _scrapper.GetOrderbook(company.Symbol, 0);
            await _unitOfWork.OrderBooks.Add(orderBook);
            await _unitOfWork.Save();

            company.OrderBooks.Add(orderBook);
            _unitOfWork.Companies.Update(company);
            await _unitOfWork.Save();
        }

        //Test
        [HttpPatch]
        public async Task LoadOrderBookToCompanies()
        {
            int[] ids = new int[] { 1, 80, 193, 199, 15, 303, 233, 297 };
            for (int i = 0; i < ids.Length; i++)
            {
                var company = await _unitOfWork.Companies.GetWithOrderBook(ids[i]);
                var orderBook = await _scrapper.GetOrderbook(company.Symbol, 0);
                await _unitOfWork.OrderBooks.Add(orderBook);
                await _unitOfWork.Save();

                company.OrderBooks.Add(orderBook);
                _unitOfWork.Companies.Update(company);
                await _unitOfWork.Save();
                Random rnd = new Random();
                int randomMiliseconds = rnd.Next(10000, 60000);
                Thread.Sleep(40000 + randomMiliseconds);
            }
        }
    }
}
