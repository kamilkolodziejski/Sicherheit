using SicherheitCore.Models.Concret;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SicherheitCore.Models
{
    public class PlannedTask : EntityBase
    {
        public String Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskState State { get; set; }
        public TaskPriority Priority { get; set; }        
        public Guid UserId { get; set; }
        
    }
}
