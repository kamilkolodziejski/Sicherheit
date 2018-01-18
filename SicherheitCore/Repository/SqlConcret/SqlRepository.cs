using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SqlRepository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        private readonly SicherheitCoreContext context;

        public SqlRepository(SicherheitCoreContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public TEntity GetById(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Remove(Guid id)
        {
            TEntity entity = new TEntity();
            entity.Id = id;
            context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
