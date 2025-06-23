using CarRental.Core.Domain.Entities;
using CarRental.Core.Domain.Interfaces;
using CarRental.Core.Infrastructure.Database;
using Dapper;

namespace CarRental.Core.Infrastructure.Repositories;

public class ClientRepository(PostgreSqlConnectionFactory connectionFactory)
    : BaseRepository<Client>(connectionFactory, "Clients"), IClientRepository
{
    private readonly PostgreSqlConnectionFactory _connectionFactory = connectionFactory;

    public async Task AddAsync(Client client)
    {
        const string query = 
            "INSERT INTO Clients (id, fullName, address, email) VALUES (@Id, @FullName, @Address, @Email)";
        
        using var db = _connectionFactory.CreateConnection();
        await db.ExecuteAsync(query, client);
    }

    public async Task UpdateAsync(Client client)
    {
        const string query = 
            "UPDATE Clients SET fullName = @FullName, address = @Address, email = @Email WHERE id = @Id";
        
        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(query, client);
    }
}