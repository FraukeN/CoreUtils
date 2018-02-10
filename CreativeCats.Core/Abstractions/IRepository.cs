using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CreativeCats.Core.Abstractions
{
    public interface IRepository<T>
      where T : class, IEntity, new()
    {
        Task<T> GetAsync(int Id);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(int skip, int take);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int skip, int take);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<int> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
