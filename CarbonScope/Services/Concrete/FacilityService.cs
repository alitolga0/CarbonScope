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
    public class FacilityService : IFacilityService
    {
        private readonly IBaseRepository<Facility> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FacilityService(IBaseRepository<Facility> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Facility entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Facility successfully added.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Facility successfully deleted.");
        }

        public IDataResult<List<Facility>> GetAll(Expression<Func<Facility, bool>> filter = null)
        {
            var data = _repository.GetAll(filter);
            return new SuccessDataResult<List<Facility>>(data, "Facilities listed.");
        }

        public IDataResult<Facility> GetById(Guid id)
        {
            var data = _repository.Get(x => x.Id == id);
            return new SuccessDataResult<Facility>(data, "Facility fetched.");
        }

        public async Task<IResult> Update(Facility entity)
        {
            await _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Facility successfully updated.");
        }
    }
}
