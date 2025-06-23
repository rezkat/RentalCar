using CarRental.Core.Domain.Entities;
using CarRental.Core.Domain.Interfaces;
using CarRental.Core.Infrastructure.Database;
using Dapper;

namespace CarRental.Core.Infrastructure.Repositories;

public class CarRepository(PostgreSqlConnectionFactory connectionFactory)
    : BaseRepository<Car>(connectionFactory, "Cars"), ICarRepository
{
    private readonly PostgreSqlConnectionFactory _connectionFactory = connectionFactory;

    public async Task AddAsync(Car car)
    {
        const string query = 
            "INSERT INTO Cars (id, brand, model, color, rented, whose) VALUES (@Id, @Brand, @Model, @Color, @Rented, @Whose)";
        
        using var db = _connectionFactory.CreateConnection();
        await db.ExecuteAsync(query, car);
        // обрубить соединение с бд
    }

    public async Task UpdateAsync(Car car)
    {
        const string query = 
            "UPDATE Cars SET brand = @Brand, model = @Model, color = @Color, rented = @Rented, whose = @Whose WHERE id = @Id";
        
        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(query, car);
    }
}