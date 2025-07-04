using CarbonScope.Core.Utilities.Result;
using System.Linq.Expressions;
using IResult = CarbonScope.Core.Utilities.Result.IResult;
namespace CarbonScope.Core.Service
{
    public interface IBaseService<TEntity, TKey> where TEntity : class
    {
        Task<IResult> Add(TEntity entity);
        Task<IResult> Update(TEntity entity);
        Task<IResult> Delete(TKey id);
        IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        IDataResult<TEntity> GetById(TKey id);
    }
}
