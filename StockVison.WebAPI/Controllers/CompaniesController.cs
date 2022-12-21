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
        private readonly IGPWScrapper _gpwScrapper;

        public CompaniesController(ISheetScrapper scrapper, IUnitOfWork unitOfWork, IGPWScrapper gpwScrapper)
        {
            _unitOfWork = unitOfWork;
            _gpwScrapper = gpwScrapper;
        }

        [HttpGet(Name = "GetCompanies")]
        public async Task<List<Company>> GetCompanies()
        {
            await _gpwScrapper.GPW();
                      var companies = await _gpwScrapper.GetCompanies();
            //return companies;
            return null;

        }

    }
}
