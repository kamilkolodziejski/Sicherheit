using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SicherheitCore.Models
{
    public class User : EntityBase
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual IEnumerable<PlannedTask> Tasks { get; set; }
        
    }
}
