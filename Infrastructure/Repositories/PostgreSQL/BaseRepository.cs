using CarRental.Core.Infrastructure.Database;
using Dapper;

namespace CarRental.Core.Infrastructure.Repositories;

public abstract class BaseRepository<T>
    (PostgreSqlConnectionFactory connectionFactory, string tableName)   // экземпляр с какой-то конфигурацией
{
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var query = $"SELECT * FROM {tableName}";
        
        using var connection = connectionFactory.CreateConnection();
        return await connection.QueryAsync<T>(query);
    }

    public virtual async Task<T?> GetByIdAsync(string id)
    {
        var query = $"SELECT * FROM {tableName} WHERE id = @Id";
        
        using var connection = connectionFactory.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
    }

    public virtual async Task DeleteAsync(string id)
    {
        var query = $"DELETE FROM {tableName} WHERE id = @Id";
        
        using var connection = connectionFactory.CreateConnection();
        await connection.ExecuteAsync(query, new { Id = id });
    }
}