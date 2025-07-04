using CarbonScope.Models;
using CarbonScope.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using CarbonScope.Core.Utilities.Result;
using IResult = CarbonScope.Core.Utilities.Result.IResult;
using CarbonScope.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace CarbonScope.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Facility>> GetAll()
        {
            return _facilityService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Facility> GetById(Guid id)
        {
            return _facilityService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(FacilityDto dto)
        {
            var entity = new Facility
            {
                Name = dto.Name,
                Address = dto.Address,
                CompanyId = dto.CompanyId
            };
            return await _facilityService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(FacilityDto dto)
        {
            var entity = new Facility
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                CompanyId = dto.CompanyId
            };
            return await _facilityService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _facilityService.Delete(id);
        }
    }
}
