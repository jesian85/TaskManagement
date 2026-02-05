using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagement.Domain.Enums;
using TaskStatus = TaskManagement.Domain.Enums.TaskStatus;

namespace TaskManagement.Domain.Entities;

[Table("Tasks")]
public class Task : BaseEntity<Guid>
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    [Required]
    public TaskStatus Status { get; set; } = TaskStatus.Pending;

    public DateTime? DueDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? CompletedOn { get; set; }

    /// <summary>
    /// Метод для обновления статуса
    /// </summary>
    public void MarkAsCompleted()
    {
        if (Status != TaskStatus.Completed)
        {
            Status = TaskStatus.Completed;
            CompletedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
        }
    }
    public void UpdateStatus(TaskStatus newStatus)
    {
        Status = newStatus;
        UpdatedOn = DateTime.UtcNow;
        if (newStatus == TaskStatus.Completed && !CompletedOn.HasValue)
        {
            CompletedOn = DateTime.UtcNow;
        }
    }
}