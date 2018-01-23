using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SicherheitCoreContext : DbContext
    {
        public SicherheitCoreContext(DbContextOptions<SicherheitCoreContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
