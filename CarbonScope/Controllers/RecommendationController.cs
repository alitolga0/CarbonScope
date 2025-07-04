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
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Recommendation>> GetAll()
        {
            return _recommendationService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Recommendation> GetById(Guid id)
        {
            return _recommendationService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(RecommendationDto dto)
        {
            var entity = new Recommendation
            {
                CompanyId = dto.CompanyId,
                FacilityId = dto.FacilityId,
                Description = dto.Description,
                IsResolved = dto.IsResolved
            };
            return await _recommendationService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(RecommendationDto dto)
        {
            var entity = new Recommendation
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                FacilityId = dto.FacilityId,
                Description = dto.Description,
                IsResolved = dto.IsResolved
            };
            return await _recommendationService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _recommendationService.Delete(id);
        }
    }
}
