using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WhereToGo.DAL.Base;

namespace WhereToGo.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public TEntity Get(string id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.DateModified = DateTime.UtcNow;
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.DateCreated = DateTime.UtcNow;
                entity.DateModified = DateTime.UtcNow;
            }
            Context.Set<TEntity>().AddRange(entities);
            Context.SaveChanges();
        }

        public void Remove(string id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entity.DateModified = DateTime.UtcNow;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }
    }
}
