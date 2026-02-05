using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.DTO;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task<TaskResponseDto?> GetTaskByIdAsync(Guid id);
    }

    public class TaskService(
        ITaskRepository taskRepository,
        IMapper mapper,
        ILogger<TaskService> logger) : ITaskService
    {
        private readonly ITaskRepository _taskRepository = taskRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<TaskService> _logger = logger;

        public async Task<TaskResponseDto?> GetTaskByIdAsync(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(t => t.Id == id, true);
            return _mapper.Map<TaskResponseDto>(task);
        }
    }
}