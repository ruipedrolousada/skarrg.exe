
using TaskApp.Domain.Enums;

namespace TaskApp.Domain;

public class TaskItem
{
    public string Title { get; private set; } = string.Empty;
    public Guid Id { get; private set; }
    public string? Description { get; private set; }
    public TaskStatusNow Status { get; private set; } 
    public TaskPriorityNow Priority { get; private set; } 
    public DateTime? DueDate { get; private set; } 
    public DateTime CreatedAt { get; private set; } 
    public DateTime? UpdatedAt { get; private set; }

    public TaskItem(
        string title,
        string? description,
        TaskPriorityNow priority,
        DateTime? dueDate)
    {
        this.Id = Guid.NewGuid();
        this.Title = title;
        this.Description = description;
        this.Status = TaskStatusNow.ToDo;
        this.Priority = priority;
        this.DueDate = dueDate;
        this.CreatedAt = DateTime.UtcNow;
        this.UpdatedAt = null;

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty or whitespace.", nameof(title));
        }

        if (dueDate.HasValue && dueDate.Value < DateTime.UtcNow)
        {
            throw new ArgumentException("Due date cannot be in the past.", nameof(dueDate));
        }

        if (!Enum.IsDefined(typeof(TaskPriorityNow), priority))
        {
            throw new ArgumentException("Invalid task priority.", nameof(priority));
        }

        if (!Enum.IsDefined(typeof(TaskStatusNow), Status))
        {
            throw new ArgumentException("Invalid task status.", nameof(Status));
        }
    
    }

    public void complete()
    {
        if (this.Status == TaskStatusNow.Completed)
        {
            throw new InvalidOperationException("Task is already completed.");
        } else if (this.Status == TaskStatusNow.Cancelled)
        {
            throw new InvalidOperationException("Cannot complete a cancelled task.");
        }

        this.Status = TaskStatusNow.Completed;
        this.UpdatedAt = DateTime.UtcNow;
        
    }


}

