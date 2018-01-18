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

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        private void Update()
        {
            this.UpdatedAt = DateTime.Now;
        }
        
    }
}
