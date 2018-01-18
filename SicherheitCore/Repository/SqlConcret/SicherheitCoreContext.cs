using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SicherheitCoreContext : DbContext
    {
        public SicherheitCoreContext(DbContextOptions<SicherheitCoreContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
    }
}
