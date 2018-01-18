using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.Abstract
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        Task GetByCreatedDate(DateTime date);
        Task GetByDeadlineDate(DateTime date);
        IEnumerable<Task> GetActiveTasks();
    }
}
