using TaskApp.Domain.Enums;

namespace TaskApp.Application.DTOs;

public sealed class CreateTaskRequest
{
    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }

    public TaskPriorityNow Priority { get; init; }

    public DateTime? DueDate { get; init; }
}