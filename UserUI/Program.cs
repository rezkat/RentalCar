using CarRental.Core.Applications;
using CarRental.Core.Infrastructure.Database;

namespace UserUI;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        await PostgreSQLTablesFactory.DropTableIfExists();
        await PostgreSQLTablesFactory.CreateTableAsync();
        Application.Run(new MenuForm());   // Запуск главной формы
    }
}