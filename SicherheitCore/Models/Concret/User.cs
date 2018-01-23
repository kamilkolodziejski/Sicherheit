using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SicherheitCore.Models
{
    public class User : EntityBase
    {
        [Required(ErrorMessage = "Title is required!")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        public virtual ICollection<Task> UserTasks { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }

    }
}
