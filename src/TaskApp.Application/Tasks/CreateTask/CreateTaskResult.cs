using TaskApp.Domain;
using TaskApp.Domain.Enums;

namespace TaskApp.Application.Tasks.CreateTask;

public sealed class CreateTaskResult
{
    public Guid Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }

    public TaskItemStatus Status { get; init; }

    public TaskPriority Priority { get; init; }

    public DateTime? DueDate { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }

    public static CreateTaskResult FromTask(TaskItem task)
    {
        return new CreateTaskResult
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            Priority = task.Priority,
            DueDate = task.DueDate,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt
        };
    }
}
