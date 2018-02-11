using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SqlRepository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        protected readonly SicherheitCoreContext _context;

        public SqlRepository(SicherheitCoreContext context)
        {
            this._context = context;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            TEntity entity = new TEntity();
            entity.Id = id;
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
