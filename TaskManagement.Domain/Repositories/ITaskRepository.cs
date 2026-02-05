using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Domain.Repositories
{
    public interface ITaskRepository : IBaseRepository<Task> { }
}
