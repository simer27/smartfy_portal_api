using System;
using System.Linq;

namespace smartfy.portal_api.domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp);

        TEntity GetBy(Func<TEntity, bool> exp);

        bool Any(Func<TEntity, bool> exp);

        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
