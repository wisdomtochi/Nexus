
using Microsoft.EntityFrameworkCore;
using Nexus.Data.Context;
using System.Threading.Tasks;

namespace Nexus.Data.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _table;
        private readonly NexusDbContext _dbContext;

        public GenericRepository(NexusDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public IQueryable<T> ReadAllQuery()
        {
            return _table.AsQueryable();
        }   

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> ReadSingleAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public void Update(Guid entityId, T entity)
        {
            _table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guid entityId)
        {
            var entity = await ReadSingleAsync(entityId);

            _table.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            bool result;
            try
            {
                result = await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }

            return result;
        }
    }
}
