using CarbonScope.Core.Repository;
using IResult = CarbonScope.Core.Utilities.Result.IResult;
using CarbonScope.Models;
using CarbonScope.Services.Abstract;
using System.Linq.Expressions;
using CarbonScope.Core.Utilities.Result;

namespace CarbonScope.Services.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly IBaseRepository<Company> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IBaseRepository<Company> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Company entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Company successfully added.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Company successfully deleted.");
        }


        public IDataResult<List<Company>> GetAll(Expression<Func<Company, bool>> filter = null)
        {
            var data = _repository.GetAll(filter);
            return new SuccessDataResult<List<Company>>(data, "Companies listed.");
        }

        public IDataResult<Company> GetById(Guid id)
        {
            var data = _repository.Get(x => x.Id == id);
            return new SuccessDataResult<Company>(data, "Company fetched.");
        }

        public async Task<IResult> Update(Company entity)
        {
            await _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Company successfully updated.");
        }
    }
}
