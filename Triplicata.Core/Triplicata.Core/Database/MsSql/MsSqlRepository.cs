using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Triplicata.Core.Types;

namespace Triplicata.Core.Database.MsSql
{
    public class MsSqlRepository<TEntity> : IMsSqlRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _context;
        protected DbSet<TEntity> _entities;
        public MsSqlRepository(DbContext context)
        {
            this._context = context;
            this._entities = context.Set<TEntity>();
        }
        public Task<TEntity> GetAsync(Guid id)
            => GetAsync(e => e.Id == id);

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            =>_entities.Where(predicate).SingleOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await _entities.Where(predicate).ToListAsync();

        public Task<PagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
                TQuery query) where TQuery : PagedQueryBase
            => _entities.Where(predicate).PaginateAsync(query);

        public async Task AddAsync(TEntity entity)
            => await _entities.AddAsync(entity);

        public async Task UpdateAsync(TEntity entity)
            => _entities.Update(entity);

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            _entities.Remove(entity);
        }
        //=> await _entities.Remove(e => e.Id == id);

        public  Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
            => _entities.AnyAsync(predicate);

        public IEnumerable<TData> Execute<TData>(IDbCommand command) where TData : class
        {
            using (var record = command.ExecuteReader())
            {
                List<TData> items = new List<TData>();
                while (record.Read())
                {

                    items.Add(Map<TData>(record));
                }
                return items;
            }
        }
        protected TData Map<TData>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<TData>();
            foreach (var property in typeof(TData).GetProperties())
            {
                bool exists = Enumerable.Range(0, record.FieldCount).Any(x => record.GetName(x) == property.Name);
                if (exists && !record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);
            }
            return objT;
        }

    }
}
