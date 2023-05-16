using AuthApp.Core.Entities.Base;
using AuthApp.Core.Repositories.Base;
using AuthApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Infrastructure.Repositories.Base;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly AuthAppDbContext _dbContext;

    public Repository(AuthAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id.ToString() == id, cancellationToken);
    }

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entities;
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().UpdateRange(entities);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().RemoveRange(entities);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}