using SicherheitCore.Models;
using SicherheitCore.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SqlTaskRepository : SqlRepository<Task>, ITaskRepository
    {
        private readonly SicherheitCoreContext _context;

        public SqlTaskRepository(SicherheitCoreContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Task> GetUserTasks(Guid userId)
        {
            return _context.Set<Task>().Where(x => (x.UserId == userId));
        }

    }
}
