using CarRental.Core.Domain.Entities;
using CarRental.Core.Infrastructure.Database;
using CarRental.Core.Domain.Interfaces;
using CarRental.Core.Infrastructure.Repositories;
using CarRepository = CarRental.Core.Infrastructure.Repositories.CarRepository;


public class Program
{
    private static readonly ITransactionRepository TransactionRepository = new TransactionRepository(new PostgreSqlConnectionFactory());
    private static readonly ICarRepository CarRepository = new CarRepository(new PostgreSqlConnectionFactory());
    private static readonly IClientRepository ClientRepository = new ClientRepository(new PostgreSqlConnectionFactory());
    private static readonly ITgClientRepository TgClientRepository = new TgClientRepository(new PostgreSqlConnectionFactory());

    // static async Task AddCarWithWhose()
    // {
    //     // transaction create
    //     DateTime signingDate = DateTime.Now;
    //     Thread.Sleep(120);
    //     DateTime endDate = DateTime.Now;
    //     var transaction = new Transaction("12", "1", "whose", signingDate, endDate);
    //     await TransactionRepository.AddAsync(transaction);
    //     
    //     var car = new Car("С075ТА196", "BMW", "X7", "BLACK", null, "12");
    //     await CarRepository.AddAsync(car);
    // }
    
    static async Task Main()
    {
        // создание таблиц
        await PostgreSQLTablesFactory.DropTableIfExists();
        await PostgreSQLTablesFactory.CreateTableAsync();
        
        // Тесты на клиентов
        await AddClients();                     // 1. добавление клиента
        await GetClientByIdAndPrintAdress();    // 2. получение информации
        await UpdateClients();                  // 3. обновление данных о клиенте

        // Тесты на тг-клиентов
        // 1. получение информации о клиенте (глубокое)
        // 2. обновление информации о клиенте (глубокое)
        // 3. обновление статуса диалога
        await AddTgClients();
        await GetTgClientByIdAndPrintInfo();
        await ClientChangeTgAccount();
        
        // Тесты на машины
        await AddCarsWithNulls();
        await GetCarByIdAndPrintColor();
        await GetAllCars();
    }
   

    static async Task AddCarsWithNulls()
    {
        var car1 = new Car("М075ОО196", "Toyota", "Corolla", "Silver", null, null);
        var car2 = new Car("А385ЕМ196", "BMW", "X3", "Black", null, null);
        var car3 = new Car("М075АА196", "BMW", "X7", "BLACK", null, null);

        await CarRepository.AddAsync(car1);
        await CarRepository.AddAsync(car2);
        await CarRepository.AddAsync(car3);
    }
    
    static async Task GetCarByIdAndPrintColor()
    {
        var car = await CarRepository.GetByIdAsync("М075ОО196");
        if (car is not null)
            Console.WriteLine($"Color: {car.Color}");
        else 
            Console.WriteLine("Not found");
    }

    static async Task GetAllCars()
    {
        var cars = await CarRepository.GetAllAsync();

        foreach (var car in cars)
            Console.WriteLine(car is not null
                ? $"ID: {car.Id}, Brand: {car.Brand}, Model: {car.Model}, Color: {car.Color}, Rented: {car.Rented}, Whose: {car.Whose}"
                : "No cars found.");
    }
    
    static async Task AddClients()
    {
        var client1 = new Client("1", "Иван Петров", "Екатеринбург, ул. Ленина, 12", "ivan.petrov@mail.ru");
        var client2 = new Client("2", "Анна Смирнова", "Екатеринбург, ул. Мира, 4", "anna.smirnova@mail.ru");
        var client3 = new Client("3", "Дмитрий Орлов", "Екатеринбург, ул. Победы, 1",  "dmitriy.orlov@mail.ru");
        
        await ClientRepository.AddAsync(client1);
        await ClientRepository.AddAsync(client2);
        await ClientRepository.AddAsync(client3);
    }

    static async Task AddTgClients()
    {
        var tgClient1 = new TgClient("tg1", "1", "active");
        var tgClient2 = new TgClient("tg2", "2", "idle");
        // клиент 3 не имеет привязки тг аккаунта
        
        await TgClientRepository.AddAsync(tgClient1);
        await TgClientRepository.AddAsync(tgClient2);
    }
    
    static async Task GetClientByIdAndPrintAdress()
    {
        var client = await ClientRepository.GetByIdAsync("1");
        if (client is not null)
            Console.WriteLine($"Adress: {client.Address}");
        else 
            Console.WriteLine("Not found");
    }
    
    static async Task UpdateClients()
    {
        var client = await ClientRepository.GetByIdAsync("1");
        if (client is null)
        {
            Console.WriteLine("Client not found");
            return;
        }
        client.Address = "Екатеринбург, ул. Мира, 3";
        client.Email = "hzkakoyemail.gmail.com";
        await ClientRepository.UpdateAsync(client);
    }
    
    static async Task GetTgClientByIdAndPrintInfo()
    {
        var tgClient = await TgClientRepository.GetByIdAsync("1");
        if (tgClient is not null)
        {
            var client = await ClientRepository.GetByIdAsync(tgClient.ClientId);
            if (client is null)
            {
                Console.WriteLine("Client not found");
                return;
            }
            Console.WriteLine($"ClientId: {tgClient.ClientId}, TgId: {tgClient.Id}, Email: {client.Email}");
        }
        else Console.WriteLine("TgClient not found");
    }

    static async Task ClientChangeTgAccount()
    {
        var tgClient = await TgClientRepository.GetByIdAsync("1");
        if (tgClient is null)
        {
            Console.WriteLine("TgClient not found");
            return;
        }
        var id = tgClient.ClientId;
        await TgClientRepository.DeleteAsync("1");
        var newtgClient = new TgClient("5", id, "active");
        await TgClientRepository.AddAsync(newtgClient);
    }
    
}