
namespace OnlineCaterer.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(object id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public TEntity? Insert(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Add(entity);
        return entry.Entity;
    }

    public TEntity? Update(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Update(entity);
        return entry.Entity;
    }

    public TEntity? Delete(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Remove(entity);
        return entry.Entity;
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _context.Set<TEntity>();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
