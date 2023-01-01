using Microsoft.AspNetCore.Mvc;
using StockVision.Core.Interfaces;
using StockVision.Core.Models;

namespace StockVison.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetCompanies")]
        public async Task<IEnumerable<Company>> GetSectors()
        {
            var companies = await _unitOfWork.Companies.GetAllWithIndexesAndSectors();
            //var sectorsWithoutDuplicates = sectors.DistinctBy(s => s.Name);
            return companies;
        }
    }
}
