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
    public class RecommendationService : IRecommendationService
    {
        private readonly IBaseRepository<Recommendation> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RecommendationService(IBaseRepository<Recommendation> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Recommendation entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Recommendation successfully added.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Recommendation successfully deleted.");
        }

        public IDataResult<List<Recommendation>> GetAll(Expression<Func<Recommendation, bool>> filter = null)
        {
            var data = _repository.GetAll(filter);
            return new SuccessDataResult<List<Recommendation>>(data, "Recommendations listed.");
        }

        public IDataResult<Recommendation> GetById(Guid id)
        {
            var data = _repository.Get(x => x.Id == id);
            return new SuccessDataResult<Recommendation>(data, "Recommendation fetched.");
        }

        public async Task<IResult> Update(Recommendation entity)
        {
            await _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Recommendation successfully updated.");
        }
    }
}
