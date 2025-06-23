using System.Data;
using Npgsql;

namespace CarRental.Core.Infrastructure.Database;

// using Microsoft.Extensions.Configuration;

// private readonly string _connectionString;

// public PostgreSqlConnectionFactory(IConfiguration configuration)
// {
//     _connectionString = configuration.GetConnectionString("DefaultConnection") 
//                         ?? throw new InvalidOperationException("Connection string not found.");
// }

public class PostgreSqlConnectionFactory
{
    private const string ConnectionString =
        "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres;";
    
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(ConnectionString);
    }
}
