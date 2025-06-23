namespace CarRental.Core.Domain.Interfaces;


public interface IDataRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(string id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}