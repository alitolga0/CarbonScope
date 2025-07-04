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
    public class ConsumptionRecordService : IConsumptionRecordService
    {
        private readonly IBaseRepository<ConsumptionRecord> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ConsumptionRecordService(IBaseRepository<ConsumptionRecord> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IResult> Add(ConsumptionRecord entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Consumption record successfully added.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Consumption record successfully deleted.");
        }

        public IDataResult<List<ConsumptionRecord>> GetAll(Expression<Func<ConsumptionRecord, bool>> filter = null)
        {
            var data = _repository.GetAll(filter);
            return new SuccessDataResult<List<ConsumptionRecord>>(data, "Consumption records listed.");
        }

        public IDataResult<ConsumptionRecord> GetById(Guid id)
        {
            var data = _repository.Get(x => x.Id == id);
            return new SuccessDataResult<ConsumptionRecord>(data, "Consumption record fetched.");
        }

        public async Task<IResult> Update(ConsumptionRecord entity)
        {
            await _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Consumption record successfully updated.");
        }
    }
}
