namespace LynxPro.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILynxRepository LynxRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        int SaveChanges();
    }
}