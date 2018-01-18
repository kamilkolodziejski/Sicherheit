using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        void Add(TEntity entity);

        TEntity GetById(Guid id);

        void Remove(Guid id);

        void Update(TEntity entity);

    }
}
