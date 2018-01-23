using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SicherheitCore.Repository.Abstract
{
    public interface ITaskRepository : IRepository<Task>
    {

        IEnumerable<Task> GetUserTasks(Guid userId);
        
    }
}
