using CarRental.Core.Domain.Entities;
using CarRental.Core.Domain.Interfaces;
using CarRental.Core.Infrastructure.Database;
using Dapper;

namespace CarRental.Core.Infrastructure.Repositories;

public class TransactionRepository(PostgreSqlConnectionFactory connectionFactory)
    : BaseRepository<Transaction>(connectionFactory, "Transactions"), ITransactionRepository
{
    private readonly PostgreSqlConnectionFactory _connectionFactory = connectionFactory;

    public async Task AddAsync(Transaction transaction)
    {
        const string query = 
            "INSERT INTO Transactions (id, clientId, OperationName, SigningDate, EndDate) VALUES (@Id, @ClientId, @OperationName, @SigningDate, @EndDate)";
        
        using var db = _connectionFactory.CreateConnection();
        await db.ExecuteAsync(query, transaction);
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        const string query = 
            "UPDATE Transactions SET clientId = @ClientId, operationId = @OperationId, SigningDate = @SigningDate, EndDate = @EndDate WHERE Id = @Id";
        
        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(query, transaction);
    }
}