namespace simpleCrud.Infrastructure.DbContexts;

public class AppQueryContext : ReadableDbContext
{
    public DbSet<Client> Clients { get; set; }

    public AppQueryContext(DbContextOptions<AppQueryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}