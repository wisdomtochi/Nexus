namespace Nexus.Data.GenericRepository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> ReadSingleAsync(Guid id);
        Task<IEnumerable<T>> ReadAllAsync();
        Task AddAsync(T entity);
        void Update(Guid entityId, T entity);
        Task DeleteAsync(Guid entityId);
        Task<bool> SaveChangesAsync();
    }
}
