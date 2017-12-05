using CreativeCats.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CreativeCats.Core.Data
{
    public class SQLiteRepository<T> : IRepository<T>
         where T : class, IEntity, new()
    {
        private SQLiteConnection _connection;

        public SQLiteRepository(ISQLite sqlite)
        {
            _connection = sqlite.GetConnection();
        }

        public Task<int> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
