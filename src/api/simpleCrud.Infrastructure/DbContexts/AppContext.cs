namespace simpleCrud.Infrastructure.DbContexts;

public class AppContext : WritableDbContext
{
    public DbSet<Client> Clients { get; set; }

    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    public AppContext(
        DbContextOptions<AppContext> options,
        IMediator mediator) : base(options, mediator) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}