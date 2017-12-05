using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreativeCats.Core.Abstractions
{
    public interface IRepository<T>
      where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int Id);
        Task<int> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
