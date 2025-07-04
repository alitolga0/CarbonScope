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
    public class TaskAssignmentController : ControllerBase
    {
        private readonly ITaskAssignmentService _taskAssignmentService;

        public TaskAssignmentController(ITaskAssignmentService taskAssignmentService)
        {
            _taskAssignmentService = taskAssignmentService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<TaskAssignment>> GetAll()
        {
            return _taskAssignmentService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<TaskAssignment> GetById(Guid id)
        {
            return _taskAssignmentService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(TaskAssignmentDto dto)
        {
            var entity = new TaskAssignment
            {
                AssignedUserId = dto.AssignedUserId,
                Description = dto.Description,
                DueDate = dto.DueDate,
                IsCompleted = dto.IsCompleted
            };
            return await _taskAssignmentService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(TaskAssignmentDto dto)
        {
            var entity = new TaskAssignment
            {
                Id = dto.Id,
                AssignedUserId = dto.AssignedUserId,
                Description = dto.Description,
                DueDate = dto.DueDate,
                IsCompleted = dto.IsCompleted
            };
            return await _taskAssignmentService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _taskAssignmentService.Delete(id);
        }
    }
}
