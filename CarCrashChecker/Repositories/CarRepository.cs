using CarCrashChecker.Data;
using CarCrashChecker.Entities;
using CarCrashChecker.Interfaces;

namespace CarCrashChecker.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarDbContext context) : base(context) { }
    }
}
