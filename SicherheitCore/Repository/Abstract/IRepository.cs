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
        Task<TEntity> GetByIdAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task AddAsync(TEntity entity);

        Task RemoveAsync(Guid id);

        Task UpdateAsync(TEntity entity);

    }
}
