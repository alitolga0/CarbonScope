using CarbonScope.Models;
using CarbonScope.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarbonScope.Core.Utilities.Result;
using CarbonScope.Dtos;
using IResult = CarbonScope.Core.Utilities.Result.IResult;


namespace CarbonScope.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Company>> GetAll()
        {
            return _companyService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Company> GetById(Guid id)
        {
            return _companyService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(CompanyDto dto)
        {
            var entity = new Company
            {
                Name = dto.Name,
                Sector = dto.Sector
            };
            return await _companyService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(CompanyDto dto)
        {
            var entity = new Company
            {
                Id = dto.Id,
                Name = dto.Name,
                Sector = dto.Sector
            };
            return await _companyService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _companyService.Delete(id);
        }
    }
}
