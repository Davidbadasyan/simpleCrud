namespace simpleCrud.Infrastructure.Repositories.Clients;

//Adapter
public class ClientRepository : IClientRepository
{
    private readonly AppContext _context;
    public ClientRepository(AppContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    public async Task<Client?> GetByIdAsync(long id)
    {
        return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task DeleteByIdAsync(long id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(c=>c.Id == id);
        if(client is  null)
        {
            return;
        }

        _context.Clients.Remove(client);
    }

    public IUnitOfWork UnitOfWork => _context;
}