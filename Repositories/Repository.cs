using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly BankingDbContext dbContext;
    protected readonly DbSet<T> dbSet;

    public Repository(BankingDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = this.dbContext.Set<T>();
    }

    public async Task<T> GetByIdAsync(object id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbSet.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await dbSet.AnyAsync(predicate);
    }
}
