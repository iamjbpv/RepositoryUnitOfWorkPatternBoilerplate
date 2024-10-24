namespace CarCrashChecker.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository CarRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
