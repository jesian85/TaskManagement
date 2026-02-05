using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.DTO
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "Заголовок является обязательным полем")]
        [MaxLength(100, ErrorMessage = "Заголовок не может превышать 100 символов")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "Описание не может превышать 500 символов")]
        public string? Description { get; set; }

        [Range(0, 3, ErrorMessage = "Приоритет должен быть от 0 до 3")]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public DateTime? DueDate { get; set; }
    }
}