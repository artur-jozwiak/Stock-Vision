using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Interfaces;
using StockVision.Core.Models;
using StockVision.Service.Interfaces;
using StockVison.Scraper;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGPWCompositionReader _gpwCompositionReader;
 
        public CompaniesController(ISheetScrapper scrapper, IUnitOfWork unitOfWork, IGPWCompositionReader gpwCompositionReader)
        {
            _unitOfWork = unitOfWork;
            _gpwCompositionReader = gpwCompositionReader;

        }

        [HttpGet(Name = "GetCompanies")]
        public async Task<List<Company>> GetCompanies()
        {
           var r =  _gpwCompositionReader.ReadLinesFromTxtFile();
            return null;

        }

    }
}
