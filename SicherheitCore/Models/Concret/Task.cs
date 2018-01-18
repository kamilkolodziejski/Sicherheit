using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Models
{
    public class Task : EntityBase
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskType Type { get; set; }
        public TaskPriority Priority { get; set; }


        public enum TaskType { Active=2, New=0, Done=1 , Canceled=-1};
        public enum TaskPriority { Low=1, Medium=1, High=2, };
    }
}
