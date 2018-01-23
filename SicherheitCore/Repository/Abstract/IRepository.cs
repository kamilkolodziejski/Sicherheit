using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SicherheitCore
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetWithFilters(Expression<Func<TEntity, bool>> exp);

        void Add(TEntity entity);

        void Remove(Guid id);

        void Update(TEntity entity);

    }
}
