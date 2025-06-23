using System.Data;
using CarRental.Core.Domain.Entities;
using CarRental.Core.Domain.Interfaces;
using CarRental.Core.Infrastructure.Database;
using Dapper;

namespace CarRental.Core.Infrastructure.Repositories;

public class TgClientRepository(PostgreSqlConnectionFactory connectionFactory)
    : BaseRepository<TgClient>(connectionFactory, "TgClients"), ITgClientRepository
{
    private readonly PostgreSqlConnectionFactory _connectionFactory = connectionFactory;


    public async Task AddAsync(TgClient tgClient)
    {
        const string query = 
            "INSERT INTO TgClients (id, clientId, dialogStatus) VALUES (@Id, @ClientId, @DialogStatus)";

        using IDbConnection db = _connectionFactory.CreateConnection();
        await db.ExecuteAsync(query, tgClient);
    }

    public async Task UpdateAsync(TgClient tgClient)
    {
        const string query = 
            "UPDATE TgClients SET clientId = @ClientId, dialogStatus = @DialogStatus WHERE id = @Id";
        
        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(query, tgClient);
    }

}