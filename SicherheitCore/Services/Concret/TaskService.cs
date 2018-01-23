using Microsoft.AspNetCore.Mvc;
using SicherheitCore.Models;
using SicherheitCore.Repository.Abstract;
using SicherheitCore.Repository.SqlConcret;
using SicherheitCore.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Guid CreateTask(Task inputTask)
        {
            Task task = new Task();
            if(String.IsNullOrWhiteSpace(inputTask.Title))
            {
                throw new ArgumentException("Title cannot be empty!");
            }
            task.Title = inputTask.Title;
            task.Type = Task.TaskType.New;
            task.Priority = inputTask.Priority;
            if(inputTask.Deadline!= null)
            {
                task.Deadline = inputTask.Deadline;
            }
            var id = _userService.CurrentUser().Id;
            if (id == null)
                throw new InvalidOperationException("Cannot create task for this user!");
            _taskRepository.Add(task);
            return task.Id;
        }

        public Task GetTask(Guid taskId)
        {
            return _taskRepository.GetById(taskId);
        }

        public IEnumerable<Task> GetUserTasks(Guid id)
        {
            return _userService.GetUser(id).UserTasks;
        }

        private IEnumerable<Task> GetCurrentUserTasks()
        {
            return _userService.CurrentUser().UserTasks;
        }

        public IEnumerable<Task> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public void DeleteTask(Guid guid)
        {
            _taskRepository.Remove(guid);
        }

        public void UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }
        
    }
}
