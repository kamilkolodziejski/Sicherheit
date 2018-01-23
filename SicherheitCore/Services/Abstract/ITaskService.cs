using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SicherheitCore.Services.Abstract
{
    public interface ITaskService
    {

        Guid CreateTask(Task task);

        Task GetTask(Guid taskId);

        IEnumerable<Task> GetUserTasks(Guid userId);

        IEnumerable<Task> GetAll();

        void DeleteTask(Guid guid);

        void UpdateTask(Task task);
    }
}
