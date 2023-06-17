namespace simpleCrud.Infrastructure.Repositories;

public abstract class BaseQueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    protected readonly AppQueryContext Context;
    protected BaseQueryRepository(AppQueryContext context)
    {
        Context = context;
    }

    public async Task<TEntity> GetByIdAsync(
        long id,
        Expression<Func<TEntity, object>>? include = null)
    {
        var query = BuildQuery(include: include);
        return await query.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TEntity>> GetWhereAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, object>>? include = null)
    {
        var query = BuildQuery(predicate: predicate, include: include);
        return await query.ToListAsync();
    }

    //TODO: change include expression more flexible
    private IQueryable<TEntity>? BuildQuery(
        Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, object>>? include = null)
    {
        var set = Context.Set<TEntity>();
        IQueryable<TEntity> query = null;

        if (include != null)
        {
            query = set.Include(include).AsQueryable();
        }

        query ??= set.AsQueryable();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return query;
    }
}