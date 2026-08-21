
using TaskApp.Domain;
using TaskApp.Domain.Enums;

namespace TaskApp.Domain.Entities;

public class TaskItem
{
    public string Title { get; private set; } = string.Empty;
    public Guid Id { get; private set; }
    public string? Description { get; private set; }
    public TaskItemStatus Status { get; private set; }
    public TaskPriority Priority { get; private set; }
    public DateTime? DueDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public TaskItem(
        string title,
        string? description,
        TaskPriority priority,
        DateTime? dueDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = TaskItemStatus.ToDo;
        Priority = priority;
        DueDate = dueDate;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty or whitespace.", nameof(title));
        }

        if (dueDate.HasValue && dueDate.Value < DateTime.UtcNow)
        {
            throw new ArgumentException("Due date cannot be in the past.", nameof(dueDate));
        }

        if (!Enum.IsDefined(typeof(TaskPriority), priority))
        {
            throw new ArgumentException("Invalid task priority.", nameof(priority));
        }

        if (!Enum.IsDefined(typeof(TaskItemStatus), Status))
        {
            throw new ArgumentException("Invalid task status.", nameof(Status));
        }
    }

    public void ChangeTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty or whitespace.", nameof(title));
        }

        Title = title;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        if (Status == TaskItemStatus.Completed)
        {
            throw new InvalidOperationException("Task is already completed.");
        }

        if (Status == TaskItemStatus.Cancelled)
        {
            throw new InvalidOperationException("Cannot complete a cancelled task.");
        }

        Status = TaskItemStatus.Completed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
        if (Status == TaskItemStatus.Cancelled)
        {
            throw new InvalidOperationException("Task is already cancelled.");
        }

        if (Status == TaskItemStatus.Completed)
        {
            throw new InvalidOperationException("Cannot cancel a completed task.");
        }

        Status = TaskItemStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
    }
}

