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
    public class ConsumptionRecordController : ControllerBase
    {
        private readonly IConsumptionRecordService _consumptionRecordService;

        public ConsumptionRecordController(IConsumptionRecordService consumptionRecordService)
        {
            _consumptionRecordService = consumptionRecordService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<ConsumptionRecord>> GetAll()
        {
            return _consumptionRecordService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<ConsumptionRecord> GetById(Guid id)
        {
            return _consumptionRecordService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(ConsumptionRecordDto dto)
        {
            var entity = new ConsumptionRecord
            {
                FacilityId = dto.FacilityId,
                ConsumptionTypeId = dto.ConsumptionTypeId,
                Value = dto.Value,
                RecordDate = dto.RecordDate
            };
            return await _consumptionRecordService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(ConsumptionRecordDto dto)
        {
            var entity = new ConsumptionRecord
            {
                Id = dto.Id,
                FacilityId = dto.FacilityId,
                ConsumptionTypeId = dto.ConsumptionTypeId,
                Value = dto.Value,
                RecordDate = dto.RecordDate
            };
            return await _consumptionRecordService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _consumptionRecordService.Delete(id);
        }
    }
}
