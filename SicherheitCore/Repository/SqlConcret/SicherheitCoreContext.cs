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
            modelBuilder.Entity<PlannedTask>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<PlannedTask>()
                .HasOne<User>(s => s.User)
                .WithMany(c => c.Tasks)
                .HasForeignKey(s => s.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(u => u.User)
                .HasForeignKey(s => s.UserId)
                .IsRequired();
        }

    }
}
