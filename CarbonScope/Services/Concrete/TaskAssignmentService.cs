using CarbonScope.Core.Repository;
using IResult = CarbonScope.Core.Utilities.Result.IResult;
using CarbonScope.Models;
using CarbonScope.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarbonScope.Core.Utilities.Result;

namespace CarbonScope.Services.Concrete
{
    public class TaskAssignmentService : ITaskAssignmentService
    {
        private readonly IBaseRepository<TaskAssignment> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskAssignmentService(IBaseRepository<TaskAssignment> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(TaskAssignment entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Task assignment successfully added.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Task assignment successfully deleted.");
        }

        public IDataResult<List<TaskAssignment>> GetAll(Expression<Func<TaskAssignment, bool>> filter = null)
        {
            var data = _repository.GetAll(filter);
            return new SuccessDataResult<List<TaskAssignment>>(data, "Task assignments listed.");
        }

        public IDataResult<TaskAssignment> GetById(Guid id)
        {
            var data = _repository.Get(x => x.Id == id);
            return new SuccessDataResult<TaskAssignment>(data, "Task assignment fetched.");
        }

        public async Task<IResult> Update(TaskAssignment entity)
        {
            await _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Task assignment successfully updated.");
        }
    }
}
