using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SqlRepository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        protected readonly SicherheitCoreContext context;

        public SqlRepository(SicherheitCoreContext context)
        {
            this.context = context;
        }

        public TEntity GetById(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetWithFilters(Expression<Func<TEntity, bool>> exp)
        {
            return context.Set<TEntity>().Where(exp);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            TEntity entity = new TEntity();
            entity.Id = id;
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
