using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Infrastructure.Persistence
{
    public class TaskManagmentDbContext(DbContextOptions<TaskManagmentDbContext> options) : DbContext(options)
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}