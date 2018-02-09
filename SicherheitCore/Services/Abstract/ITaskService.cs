using SicherheitCore.Models;
using SicherheitCore.Models.Concret;
using SicherheitCore.Models.ModelsDto;
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
        Task<PlannedTaskDto> GetTask(Guid taskId);
        Task<IEnumerable<PlannedTaskDto>> GetUserTasks(Guid userId);
        Task Delete(Guid taskId);
        Task ChangeTask(Guid taskId, String name, String description);
        Task ChangeTaskPriority(Guid taskId, TaskPriority priority);
        Task CloseTask();
        Task OpenTask();
        Task CancelTask();
    }
}
