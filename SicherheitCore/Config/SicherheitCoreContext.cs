using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using System;

namespace SicherheitCore.Repository.SqlConcret
{
    public class SicherheitCoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PlannedTask> Tasks { get; set; }

        public SicherheitCoreContext(DbContextOptions<SicherheitCoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityBase>()
                .HasKey(t => t.Id);
        }

    }
}
