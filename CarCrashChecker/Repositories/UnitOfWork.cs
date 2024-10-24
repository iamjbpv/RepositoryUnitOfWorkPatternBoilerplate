using CarCrashChecker.Data;
using CarCrashChecker.Interfaces;

namespace CarCrashChecker.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarDbContext _context;
        private ICarRepository _carRepository;

        public UnitOfWork(CarDbContext context)
        {
            _context = context;
        }

        public ICarRepository CarRepository
        {
            get { return _carRepository ??= new CarRepository(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
