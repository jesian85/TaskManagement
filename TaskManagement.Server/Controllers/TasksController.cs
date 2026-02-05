using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTO;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Enums;
using TaskManagement.Shared;
using TaskStatus = TaskManagement.Domain.Enums.TaskStatus;

namespace TaskManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController(ITaskService taskService, ILogger<TasksController> logger) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;
        private readonly ILogger<TasksController> _logger = logger;

        ///// <summary>
        ///// Получить список задач с пагинацией и фильтрацией
        ///// </summary>
        //[HttpGet]
        //[ProducesResponseType(typeof(PagedResult<TaskResponseDto>), StatusCodes.Status200OK)]
        //public async Task<ActionResult<PagedResult<TaskResponseDto>>> GetTasks(
        //    [FromQuery] int pageNumber = 1,
        //    [FromQuery] int pageSize = 20,
        //    [FromQuery] TaskStatus? status = null,
        //    [FromQuery] TaskPriority? priority = null)
        //{
        //    _logger.LogInformation("Getting tasks with page {PageNumber}, page size {PageSize}",
        //        pageNumber, pageSize);

        //    try
        //    {
        //        var result = await _taskService.GetTasksAsync(pageNumber, pageSize, status, priority);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error getting tasks");
        //        return StatusCode(500, "An error occurred while processing your request");
        //    }
        //}

        /// <summary>
        /// Получить задачу по ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaskResponseDto>> GetTask(Guid id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                _logger.LogWarning("Задача не найдена (Id={TaskId})", id);
                return NotFound();
            }

            return Ok(task);
        }

        ///// <summary>
        ///// Создать новую задачу
        ///// </summary>
        //[HttpPost]
        //[ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<TaskResponseDto>> CreateTask(CreateTaskDto createTaskDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var task = await _taskService.CreateTaskAsync(createTaskDto);

        //    _logger.LogInformation("Created task with ID {TaskId}", task.Id);

        //    return CreatedOnAction(nameof(GetTask), new { id = task.Id }, task);
        //}

        ///// <summary>
        ///// Обновить задачу
        ///// </summary>
        //[HttpPut("{id:guid}")]
        //[ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<TaskResponseDto>> UpdateTask(Guid id, UpdateTaskDto updateTaskDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var task = await _taskService.UpdateTaskAsync(id, updateTaskDto);

        //    if (task == null)
        //    {
        //        return NotFound();
        //    }

        //    _logger.LogInformation("Updated task with ID {TaskId}", id);

        //    return Ok(task);
        //}

        ///// <summary>
        ///// Изменить статус задачи
        ///// </summary>
        //[HttpPatch("{id:guid}/status")]
        //[ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<TaskResponseDto>> UpdateTaskStatus(Guid id, [FromBody] TaskStatus status)
        //{
        //    var task = await _taskService.UpdateTaskStatusAsync(id, status);

        //    if (task == null)
        //    {
        //        return NotFound();
        //    }

        //    _logger.LogInformation("Updated status of task with ID {TaskId} to {Status}", id, status);

        //    return Ok(task);
        //}

        ///// <summary>
        ///// Удалить задачу
        ///// </summary>
        //[HttpDelete("{id:guid}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeleteTask(Guid id)
        //{
        //    var success = await _taskService.DeleteTaskAsync(id);

        //    if (!success)
        //    {
        //        return NotFound();
        //    }

        //    _logger.LogInformation("Deleted task with ID {TaskId}", id);

        //    return NoContent();
        //}

        ///// <summary>
        ///// Получить статистику по задачам
        ///// </summary>
        //[HttpGet("stats")]
        //[ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        //public async Task<ActionResult<object>> GetStats()
        //{
        //    var stats = await _taskService.GetStatsAsync();
        //    return Ok(stats);
        //}
    }
}
