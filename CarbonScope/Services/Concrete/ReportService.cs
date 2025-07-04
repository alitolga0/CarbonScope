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
    public class ReportService : IReportService
    {
        private readonly IBaseRepository<Report> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IBaseRepository<Report> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Report entity)
        {
            await _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Report successfully added.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Report successfully deleted.");
        }

        public IDataResult<List<Report>> GetAll(Expression<Func<Report, bool>> filter = null)
        {
            var data = _repository.GetAll(filter);
            return new SuccessDataResult<List<Report>>(data, "Reports listed.");
        }

        public IDataResult<Report> GetById(Guid id)
        {
            var data = _repository.Get(x => x.Id == id);
            return new SuccessDataResult<Report>(data, "Report fetched.");
        }

        public async Task<IResult> Update(Report entity)
        {
            await _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Report successfully updated.");
        }
    }
}
