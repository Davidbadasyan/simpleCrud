namespace simpleCrud.Domain.SeedWork;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //Task<bool> DispatchDomainEventsAsync(CancellationToken cancellationToken = default);
}