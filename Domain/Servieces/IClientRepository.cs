using CarRental.Core.Domain.Entities;

namespace CarRental.Core.Domain.Interfaces;

public interface IClientRepository : IDataRepository<Client>
{
    // Task<IEnumerable<Client>> GetClientsWithActiveRentalsAsync();
}