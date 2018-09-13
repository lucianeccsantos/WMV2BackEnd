using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        PagedResult<TEntity> GetPagedResultForQuery(IQueryable<TEntity> query, int page, int pageSize);

    }
}
