using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Interfaces;
using StockVision.Core.Models;
using StockVision.Service.Interfaces;
using StockVision.Service.Services;
using StockVison.Scraper;
using System.Net;

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
           var lines =  _gpwCompositionReader.ReadLinesFromTxtFile();
           // var companies =_gpwCompositionReader.GetCompaniesFromTxtFile(lines);
          await  _gpwCompositionReader.GetCompaniesIndexesSectorsFromTxtFile(lines);




            return null;
        }

    }
}
