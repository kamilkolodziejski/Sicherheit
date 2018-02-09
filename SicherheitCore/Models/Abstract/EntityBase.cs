using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        protected EntityBase()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        public void Updated()
        {
            this.UpdatedAt = DateTime.Now;
        }
        
    }
}
