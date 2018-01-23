using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SicherheitCore.Repository.SqlConcret
{
    public static class DbInitializer
    {
        public static void Initialize(SicherheitCoreContext context)
        {
            context.Database.EnsureCreated();
            ISet<Guid> userGuids = new HashSet<Guid>();
            if(!context.Users.Any())
            {
                for (int i = 1; i <= 5; i++)
                {
                    User user = new User();
                    user.EmailAddress = $"user{i}@testowy.pl";
                    user.Password = "111111111";
                    user.IsActive = true;
                    user.Name = $"Testowy user {i}";
                    userGuids.Add(user.Id);
                    context.Add(user);
                }
            }

            if(!context.Tasks.Any())
            for (int i=1; i<=15; i++)
            {
                Task task = new Task();
                task.Title = $"Task {i}";
                task.Priority = Task.TaskPriority.Medium;
                task.Deadline = new DateTime(2018, 03, i);
                task.Type = Task.TaskType.New;
                int r = new Random().Next(0,5);
                task.UserId = userGuids.ElementAt(r);
                context.Add(task);
            }
            context.SaveChanges();
        }
    }
}
