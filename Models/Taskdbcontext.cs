using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .Property(t => t.Priority)
                .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
