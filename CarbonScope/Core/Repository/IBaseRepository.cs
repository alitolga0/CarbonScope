using CarbonScope.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarbonScope.Core.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        List<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null);

        T? Get(
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IQueryable<T>>? include = null);

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}
