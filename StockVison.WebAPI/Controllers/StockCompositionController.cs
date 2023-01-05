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
    public class StockCompositionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGPWCompositionReader _gpwCompositionReader;
 
        public StockCompositionController(ISheetScrapper scrapper, IUnitOfWork unitOfWork, IGPWCompositionReader gpwCompositionReader)
        {
            _unitOfWork = unitOfWork;
            _gpwCompositionReader = gpwCompositionReader;
        }

        [HttpPost]
        public async Task GetStockComposition()
        {
          var lines =  _gpwCompositionReader.ReadLinesFromTxtFile();
          await  _gpwCompositionReader.GetCompaniesIndexesSectorsFromTxtFile(lines);
        }
    }
}
