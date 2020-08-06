using Dingfang.TaskManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dingfang.TaskManagementSystem.Infrastructure.Data
{
    public class TaskDbContext:DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        public DbSet<Core.Entities.TaskEntity> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.TaskEntity>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).HasMaxLength(50);
                entity.Property(t => t.Description).HasMaxLength(500);
                entity.Property(t => t.Priority).HasMaxLength(1);
                entity.Property(t => t.Remarks).HasMaxLength(500);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).HasMaxLength(50);
                entity.Property(u => u.Password).HasMaxLength(10).IsRequired();
                entity.Property(u => u.Fullname).HasMaxLength(50);
                entity.Property(u => u.Mobileno).HasMaxLength(50);



            });
            modelBuilder.Entity<TaskHistory>(entity =>
            {
                entity.ToTable("Tasks History");
                //entity.HasKey(th => new { th.TaskId, th.UserId });
                entity.HasKey(th => th.TaskId);
                //entity.Property(th => th.TaskId).ValueGeneratedNever();
                entity.Property(th => th.Title).HasMaxLength(50);
                entity.Property(th => th.Description).HasMaxLength(500);
                entity.Property(th => th.Remarks).HasMaxLength(500);
                entity.Property(th => th.UserId);
                entity.Property(th => th.DueDate);
                entity.Property(th => th.Completed);


            });
        }
    }
}
