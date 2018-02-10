using SicherheitCore.Models;
using SicherheitCore.Models.Concret;
using SicherheitCore.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Services.Abstract
{
    public interface ITaskService
    {
        Task CreateTask(String title, String description, DateTime deadline, TaskPriority priority);
        Task<PlannedTask> GetTask(Guid taskId);
        Task<IEnumerable<PlannedTask>> GetUserTasks(Guid userId);
        Task Delete(Guid taskId);
        Task ChangeTask(Guid taskId, String name, String description);
        Task ChangeTaskPriority(Guid taskId, TaskPriority priority);
        Task CloseTask(Guid taskId);
        Task OpenTask(Guid taskId);
        Task CancelTask(Guid taskId);
    }
}
