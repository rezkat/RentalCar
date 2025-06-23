using CarRental.Core.Domain.Entities;

namespace CarRental.Core.Domain.Interfaces;

public interface ICarRepository : IDataRepository<Car>
{
    //Task<IEnumerable<Car>> GetAvailableCarsAsync();
    // Task<IEnumerable<Car>> GetOwnedCarsAsync();
}