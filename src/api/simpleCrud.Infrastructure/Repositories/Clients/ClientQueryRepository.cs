namespace simpleCrud.Infrastructure.Repositories.Clients;

//Adapter
public class ClientQueryRepository : BaseQueryRepository<Client>, IClientQueryRepository
{
    public ClientQueryRepository(AppQueryContext context) : base(context)
    {
    }

    public async Task<bool> ExistsAsync(string? code)
    {
        return await Context.Clients.AnyAsync(c => c.Code == code);
    }

    public async Task<PaginatedResult<Client>> GetPaginatedAsync(
        string search,
        int pageNumber,
        int pageSize)
    {
        var queryable = Context.Clients.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            queryable = queryable.Where(c => c.Code.Contains(search) || c.Name.Contains(search));
        }

        var paginatedClients = await queryable
            .OrderByDescending(c => c.Id)
            .ToPaginatedResultAsync(pageNumber, pageSize);

        return paginatedClients;
    }
}