using SicherheitCore.Models;
using SicherheitCore.Models.Concret;
using SicherheitCore.Repository.Abstract;
using SicherheitCore.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SicherheitCore.Models.ModelsDto;

namespace SicherheitCore.Services.Concret
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;
        private IUserService _userService;

        public TaskService(ITaskRepository taskRepository, IUserService userService)
        {
            this._taskRepository = taskRepository;
            this._userService = userService;
        }

        async Task ITaskService.CreateTask(string title, string description, DateTime deadline, TaskPriority priority)
        {
            var task = new PlannedTask
            {
                Title = title,
                Deadline = deadline,
                Description = description,
                Priority = priority,
                Type = TaskState.Active,
                UserId = _userService.CurrentUser().Id
            };
            await _taskRepository.AddAsync(task);
        }

        Task<PlannedTaskDto> ITaskService.GetTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<PlannedTaskDto>> ITaskService.GetUserTasks(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task ChangeTask(Guid taskId, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task ChangeTaskPriority(Guid taskId, TaskPriority priority)
        {
            throw new NotImplementedException();
        }

        public Task CloseTask()
        {
            throw new NotImplementedException();
        }

        public Task OpenTask()
        {
            throw new NotImplementedException();
        }

        public Task CancelTask()
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid taskId)
        {
            throw new NotImplementedException();
        }
    }
}
