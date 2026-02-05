using TaskManagement.Domain.Repositories;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Infrastructure.Persistence.Repositories
{
    internal class TaskRepository(TaskManagmentDbContext dbContext) : BaseRepository<Task>(dbContext), ITaskRepository
    {
    }
}