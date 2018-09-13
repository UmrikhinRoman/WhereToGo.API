using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WhereToGo.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(string id);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity t);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    }
}
