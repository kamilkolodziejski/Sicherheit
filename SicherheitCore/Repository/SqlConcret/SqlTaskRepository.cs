using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using SicherheitCore.Repository.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SqlTaskRepository : SqlRepository<PlannedTask>, ITaskRepository
    {
        public SqlTaskRepository(SicherheitCoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PlannedTask>> getTasksByUserIdAsync(Guid userId)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
