using SicherheitCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.Abstract
{
    public interface ITaskRepository : IRepository<PlannedTask>
    {
        Task<IEnumerable<PlannedTask>> getTasksByUserIdAsync(Guid userId);
    }
}
