using AuthApp.Core.Entities.Base;
using AuthApp.Core.Repositories.Base;
using AuthApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Infrastructure.Repositories.Base;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly AuthAppContext _context;

    public Repository(AuthAppContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id.ToString() == id, cancellationToken);
    }

    public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities,
        CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddRangeAsync(entities, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return entities;
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().UpdateRange(entities);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _context.Set<T>().RemoveRange(entities);

        await _context.SaveChangesAsync(cancellationToken);
    }
}