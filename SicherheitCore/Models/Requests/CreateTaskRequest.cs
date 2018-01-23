using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Models.Requests
{
    public class CreateTaskRequest
    {
        [Required]
        [Display(Name = "Task Title")]
        [StringLength(50, ErrorMessage = "Title must have maximum 50 characters!", MinimumLength = 6)]
        public String Title { get; set; }
        
        [Display(Name = "Task Description")]
        [StringLength(500, ErrorMessage = "Title must have maximum 50 characters!")]
        public String Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Task Deadline")]
        public DateTime Deadline { get; set; }

        [Required]
        [Display(Name = "Task Priority")]
        public Task.TaskPriority Priority { get; set; }
    }
}
