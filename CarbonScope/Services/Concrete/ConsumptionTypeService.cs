using CarbonScope.Core.Repository;
using IResult = CarbonScope.Core.Utilities.Result.IResult;
using CarbonScope.Models;
using CarbonScope.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarbonScope.Core.Service;
using CarbonScope.Core.Utilities.Result;

namespace CarbonScope.Services.Concrete
{
    public class ConsumptionTypeService : IConsumptionTypeService
    {
        private readonly IBaseRepository<ConsumptionType> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ConsumptionTypeService(IBaseRepository<ConsumptionType> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(ConsumptionType entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Consumption type successfully added.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Consumption type successfully deleted.");
        }

        public IDataResult<List<ConsumptionType>> GetAll(Expression<Func<ConsumptionType, bool>> filter = null)
        {
            var data = _repository.GetAll(filter);
            return new SuccessDataResult<List<ConsumptionType>>(data, "Consumption types listed.");
        }

        public IDataResult<ConsumptionType> GetById(Guid id)
        {
            var data = _repository.Get(x => x.Id == id);
            return new SuccessDataResult<ConsumptionType>(data, "Consumption type fetched.");
        }

        public async Task<IResult> Update(ConsumptionType entity)
        {
            await _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Consumption type successfully updated.");
        }
    }
}
