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
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Report>> GetAll()
        {
            return _reportService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Report> GetById(Guid id)
        {
            return _reportService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(ReportDto dto)
        {
            var entity = new Report
            {
                CompanyId = dto.CompanyId,
                FacilityId = dto.FacilityId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ReportType = dto.ReportType,
                ReportDataJson = dto.ReportDataJson
            };
            return await _reportService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(ReportDto dto)
        {
            var entity = new Report
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                FacilityId = dto.FacilityId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ReportType = dto.ReportType,
                ReportDataJson = dto.ReportDataJson
            };
            return await _reportService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _reportService.Delete(id);
        }
    }
}
