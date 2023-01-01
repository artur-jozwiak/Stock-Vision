using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Interfaces;
using StockVision.Core.Models;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockIndexesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockIndexesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetStockIndexes")]
        public async Task<IEnumerable<StockIndex>> GetStockIndexes()
        {
            var indexes = await _unitOfWork.StockIndexes.GetAllWithCompanies();
            var indexesWithoutDuplicates =  indexes.DistinctBy(i => i.Name);
            return indexesWithoutDuplicates;
        }
    }
}
