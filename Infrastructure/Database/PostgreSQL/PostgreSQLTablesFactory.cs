using Dapper;
using Npgsql;

namespace CarRental.Core.Infrastructure.Database;

public static class PostgreSQLTablesFactory
{
    private static readonly PostgreSqlConnectionFactory ConnectionFactory = new PostgreSqlConnectionFactory();

    public static async Task DropTableIfExists()
    {
        var query = $@"
        DROP TABLE IF EXISTS TgClients   CASCADE;
        DROP TABLE IF EXISTS Cars         CASCADE;
        DROP TABLE IF EXISTS Transactions CASCADE;
        DROP TABLE IF EXISTS Clients      CASCADE;";
        
        using var db = ConnectionFactory.CreateConnection();
        await db.ExecuteAsync(query);
    }
    
    public static async Task CreateTableAsync()
    {
        var ClientsTable = $@"
        CREATE TABLE IF NOT EXISTS Clients (
            id TEXT PRIMARY KEY,    -- задаётся вручную
            fullName TEXT NOT NULL,
            address    TEXT NOT NULL,
            email      TEXT NOT NULL);";

        var TgClientsTable = $@"
        CREATE TABLE TgClients (
            id            TEXT PRIMARY KEY,   -- задаётся вручную
            clientId      TEXT NOT NULL,
            dialogStatus  TEXT NOT NULL,
            FOREIGN KEY (clientId)
                REFERENCES Clients(id)
                ON DELETE CASCADE);";

        var TransactionsTable = $@"
        CREATE TABLE Transactions (
            id                        TEXT      PRIMARY KEY,
            clientId                  TEXT      NOT NULL,
            operationName             TEXT		NOT NULL,           -- 0 или 1
            signingDate 			  TIMESTAMP NOT NULL,
            endDate     			  TIMESTAMP,
            FOREIGN KEY (clientId)
                REFERENCES Clients(id)
                ON DELETE CASCADE);";

        var CarsTable = $@"
        CREATE TABLE Cars (
            id     TEXT PRIMARY KEY,              
            brand  TEXT NOT NULL,
            model  TEXT NOT NULL,
            color  TEXT NOT NULL,
            rented TEXT,   -- NULL = свободна
            whose  TEXT,   -- NULL = машина изначально наша

            FOREIGN KEY (rented)
                REFERENCES Transactions(id)
                ON DELETE SET NULL,               -- при удалении транзакции аренды → rented = NULL
            FOREIGN KEY (whose)
                REFERENCES Transactions(id)
                ON DELETE CASCADE                 -- при удалении транзакции получения → удаляем машину
                );";
                    
        using var db = ConnectionFactory.CreateConnection();
        await db.ExecuteAsync(ClientsTable);
        await db.ExecuteAsync(TgClientsTable);
        await db.ExecuteAsync(TransactionsTable);
        await db.ExecuteAsync(CarsTable);
    }
}