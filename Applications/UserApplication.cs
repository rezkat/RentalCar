using CarRental.Core.Domain.Entities;
using CarRental.Core.Domain.Interfaces;
using CarRental.Core.Infrastructure.Database;
using CarRental.Core.Infrastructure.Repositories;

namespace CarRental.Core.Applications;

public static class UserApplication
{
    private static readonly ITransactionRepository TransactionRepository = new TransactionRepository(new PostgreSqlConnectionFactory());
    private static readonly ICarRepository CarRepository = new CarRepository(new PostgreSqlConnectionFactory());
    private static readonly IClientRepository ClientRepository = new ClientRepository(new PostgreSqlConnectionFactory());
    private static readonly ITgClientRepository TgClientRepository = new TgClientRepository(new PostgreSqlConnectionFactory());
    
    public static async Task<Car?> GetCarById(string id)
    {
        var car = await CarRepository.GetByIdAsync(id);
        if (car is not null)
            return car;
        Console.WriteLine($"Car with id: {id} was not found.");
        return null;
    }

    public static async Task<IEnumerable<Car>> GetAllCars()
    {
        var cars = await CarRepository.GetAllAsync();
        if (cars is not null)
            return cars;
        Console.WriteLine("All cars were not found.");
        return null;
    }
    
    public static async Task AddCar(Car car) => await CarRepository.AddAsync(car);
    
    public static async Task UpdateCar(Car car) => await CarRepository.UpdateAsync(car);
    
    public static async Task DeleteCar(string id) => await CarRepository.DeleteAsync(id);
    
    
    public static async Task<Client?> GetClientById(string id)
    {
        var client = await ClientRepository.GetByIdAsync(id);
        if (client is not null)
            return client;
        Console.WriteLine($"Client with id: {id} was not found.");
        return null;
    }

    public static async Task<IEnumerable<Client>> GetAllClient()
    {
        var clients = await ClientRepository.GetAllAsync();
        if (clients is not null)
            return clients;
        Console.WriteLine("All clients were not found.");
        return null;
    }

    public static async Task AddClients(Client client) => await ClientRepository.AddAsync(client);
    
    public static async Task UpdateClients(Client client) => await ClientRepository.UpdateAsync(client);

    public static async Task DeleteClient(string id) => await ClientRepository.DeleteAsync(id);
    

    public static async Task<TgClient?> GetTgClientById(string id)
    {
        var tgClient = await TgClientRepository.GetByIdAsync(id);
        if (tgClient is not null)
            return tgClient;
        Console.WriteLine($"TgClient with id: {id} was not found.");
        return null;
    }

    public static async Task<IEnumerable<TgClient>> GetAllTgClients()
    {
        var tgClients = await TgClientRepository.GetAllAsync();
        if (tgClients is not null)
            return tgClients;
        Console.WriteLine("All clients were not found.");
        return null;
    }
    
    public static async Task AddTgClients(TgClient tgClient) => await TgClientRepository.AddAsync(tgClient);

    public static async Task UpdateTgClient(TgClient tgClient) => await TgClientRepository.UpdateAsync(tgClient);


    public static async Task<Transaction?> GetTransactionById(string id)
    {
        var transaction = await TransactionRepository.GetByIdAsync(id);
        if (transaction is not null)
            return transaction;
        Console.WriteLine($"Transaction with id: {id} was not found.");
        return null;
    }

    public static async Task<IEnumerable<Transaction>> GetAllTransactions()
    {
        var transactions = await TransactionRepository.GetAllAsync();
        if (transactions is not null)
            return transactions;
        Console.WriteLine("All transactions were not found.");
        return null;
    }
    
    public static async Task AddTransaction(Transaction transaction) => await TransactionRepository.AddAsync(transaction);
    
    public static async Task UpdateTransaction(Transaction transaction) => await TransactionRepository.UpdateAsync(transaction);
    
    public static async Task DeleteTransaction(string id) => await TransactionRepository.DeleteAsync(id);
}