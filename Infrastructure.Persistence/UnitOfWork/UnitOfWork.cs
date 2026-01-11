using Domain.Common;
using Infrastructure.Persistence;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence.Repositories;
using System.Collections.Concurrent;

namespace LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderManagementDbContext _dbContext;
        private readonly ConcurrentDictionary<string, object> _repositories;
        public UnitOfWork(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new();
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_dbContext));
        }

        public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    }
}
