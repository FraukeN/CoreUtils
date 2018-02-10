using CreativeCats.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Linq.Expressions;

namespace CreativeCats.Core.Data
{
    public class SQLiteRepository<T> : IRepository<T>
         where T : class, IEntity, new()
    {
        protected readonly SQLiteAsyncConnection _SQLiteConnection;

        public SQLiteRepository(ISQLite SQLite)
        {
            if (SQLite == null) throw new ArgumentNullException("SQLite");

            _SQLiteConnection = SQLite.GetAsyncConnection();
            _SQLiteConnection.CreateTableAsync<T>().Wait();
        }

        public virtual Task DeleteAsync(T entity)
        {
            return _SQLiteConnection.DeleteAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await _SQLiteConnection.Table<T>().ToListAsync();
        }

        public virtual Task<T> GetAsync(int Id)
        {
            return _SQLiteConnection.Table<T>().Where(e => e.Id == Id).FirstOrDefaultAsync();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            if (entity.Id == 0)
            {
                await _SQLiteConnection.InsertAsync(entity);
            }
            return entity.Id;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            bool success = false;
            if (await GetAsync(entity.Id) != null)
            {
                // Existing entity - update
                await _SQLiteConnection.UpdateAsync(entity);
                success = true;
            }
            else
                throw new RepositoryException($"The entity with Id {entity.Id} does not exist.");
            return success;
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _SQLiteConnection.Table<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(int skip, int take)
        {
            return await _SQLiteConnection.Table<T>().Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, int skip, int take)
        {
            return await _SQLiteConnection.Table<T>().Where(predicate).Skip(skip).Take(take).ToListAsync();
        }

        public virtual Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return _SQLiteConnection.Table<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public virtual Task AddRangeAsync(IEnumerable<T> entities)
        {
            return _SQLiteConnection.InsertAllAsync(entities);
        }
    }
}
