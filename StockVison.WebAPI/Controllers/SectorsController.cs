using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Interfaces;
using StockVision.Core.Models;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Sector>> GetSectors()
        {
            var sectors = await _unitOfWork.Sectors.GetAllWithCompanies();
            var sectorsWithoutDuplicates = sectors.DistinctBy(s => s.Name);
            return sectorsWithoutDuplicates;
        }
    }
}
