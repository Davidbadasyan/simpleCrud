namespace simpleCrud.Domain.SeedWork;
public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }

    Task AddAsync(T client);
    Task<T?> GetByIdAsync(long id);
    Task DeleteByIdAsync(long id);
}