using System.Linq.Expressions;
using EzRent.Domain.Entities;

namespace EzRent.Domain.Repository;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> GetAsync(
        CancellationToken cancellationToken,
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeString = null,
        bool disableTracking = true);

    Task<IReadOnlyList<T>> GetAsync(
        CancellationToken cancellationToken,
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<Expression<Func<T, object>>> includes = null,
        bool disableTracking = true);

    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}