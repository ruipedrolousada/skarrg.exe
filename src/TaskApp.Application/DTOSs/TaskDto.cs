using TaskApp.Domain.Enums;

namespace TaskApp.Application.DTOs;

public sealed class TaskDto
{
    public Guid Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }

    public TaskStatusNow Status { get; init; }

    public TaskPriorityNow Priority { get; init; }

    public DateTime? DueDate { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; init; }
}