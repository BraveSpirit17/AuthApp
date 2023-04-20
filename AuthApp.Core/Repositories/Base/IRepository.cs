using AuthApp.Core.Entities.Base;

namespace AuthApp.Core.Repositories.Base;

public interface IRepository<T> where T : Entity
{
    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = new());

    Task<List<T>> ListAsync(CancellationToken cancellationToken = new());

    Task<T> AddAsync(T entity, CancellationToken cancellationToken = new());
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = new());

    Task UpdateAsync(T entity, CancellationToken cancellationToken = new());
    Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = new());

    Task DeleteAsync(T entity, CancellationToken cancellationToken = new());
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = new());
}