using SicherheitCore.Models;
using SicherheitCore.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SqlTaskRepository : ITaskRepository
    {
        public void Add(Models.Task entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<System.Threading.Tasks.Task> GetActiveTasks()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task GetByCreatedDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task GetByDeadlineDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Models.Task GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Task entity)
        {
            throw new NotImplementedException();
        }
    }
}
