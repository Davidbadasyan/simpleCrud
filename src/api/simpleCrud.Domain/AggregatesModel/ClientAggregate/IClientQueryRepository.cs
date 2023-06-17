namespace simpleCrud.Domain.AggregatesModel.ClientAggregate;

//Port
public interface IClientQueryRepository : IQueryRepository<Client>
{
    Task<bool> ExistsAsync(string? code);

    Task<PaginatedResult<Client>> GetPaginatedAsync(
        string search,
        int pageNumber,
        int pageSize);
}