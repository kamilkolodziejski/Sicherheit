using SicherheitCore.Models;
using SicherheitCore.Models.Concret;
using SicherheitCore.Repository.Abstract;
using SicherheitCore.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        async public Task CreateTask(string title, string description, DateTime deadline, TaskPriority priority)
        {
            var task = new PlannedTask
            {
                Title = title,
                Deadline = deadline,
                Description = description,
                Priority = priority,
                State = TaskState.Active,
                UserId = _userService.CurrentUser().Id
            };
            await _taskRepository.AddAsync(task);
        }

        public async Task<PlannedTask> GetTask(Guid taskId)
            => await _taskRepository.GetByIdAsync(taskId);

        public async Task<IEnumerable<PlannedTask>> GetUserTasks(Guid userId)
            => await _taskRepository.GetByUserIdAsync(userId);

        private async Task changeState(Guid taskId, TaskState state)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            task.State = state;
            await _taskRepository.UpdateAsync(task);
        }

        public async Task ChangeTask(Guid taskId, string title, string description)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            task.Title = title;
            task.Description = description;
            await _taskRepository.UpdateAsync(task);
        }

        public async Task ChangeTaskPriority(Guid taskId, TaskPriority priority)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            task.Priority = priority;
            await _taskRepository.UpdateAsync(task);
        }

        public async Task CloseTask(Guid taskId)
            => await changeState(taskId, TaskState.Done);

        public async Task OpenTask(Guid taskId)
            => await changeState(taskId, TaskState.Active);

        public async Task CancelTask(Guid taskId)
            => await changeState(taskId, TaskState.Done);

        public async Task Delete(Guid taskId)
            => await _taskRepository.RemoveAsync(taskId);
    }
}
