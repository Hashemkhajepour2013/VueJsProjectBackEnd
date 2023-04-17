using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectUserPost.Entities.Common;

namespace ProjectUserPost.Data.Repositories.Contracts;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
    void Attach(TEntity entity);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
    void Detach(TEntity entity);
    Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    
    Task LoadCollectionAsync<TProperty>(TEntity entity,
        Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty, CancellationToken cancellationToken)
        where TProperty : class;

    Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty,
        CancellationToken cancellationToken) where TProperty : class;
    
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
}