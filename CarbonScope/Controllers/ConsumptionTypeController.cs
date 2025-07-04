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
    public class ConsumptionTypeController : ControllerBase
    {
        private readonly IConsumptionTypeService _consumptionTypeService;

        public ConsumptionTypeController(IConsumptionTypeService consumptionTypeService)
        {
            _consumptionTypeService = consumptionTypeService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<ConsumptionType>> GetAll()
        {
            return _consumptionTypeService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<ConsumptionType> GetById(Guid id)
        {
            return _consumptionTypeService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(ConsumptionTypeDto dto)
        {
            var entity = new ConsumptionType
            {
                Name = dto.Name,
                Unit = dto.Unit,
                Co2Factor = dto.Co2Factor
            };
            return await _consumptionTypeService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(ConsumptionTypeDto dto)
        {
            var entity = new ConsumptionType
            {
                Id = dto.Id,
                Name = dto.Name,
                Unit = dto.Unit,
                Co2Factor = dto.Co2Factor
            };
            return await _consumptionTypeService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _consumptionTypeService.Delete(id);
        }
    }
}
