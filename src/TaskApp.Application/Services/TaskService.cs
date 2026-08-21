using TaskApp.Application.DTOs;
using TaskApp.Application.Interfaces;
using TaskApp.Domain;

namespace TaskApp.Application.Services;

public sealed class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskDto> CreateAsync(
        CreateTaskRequest request,
        CancellationToken cancellationToken = default)
    {
        var task = new TaskItem(
            request.Title,
            request.Description,
            request.Priority,
            request.DueDate);

        await _taskRepository.AddAsync(
            task,
            cancellationToken);

        await _taskRepository.SaveChangesAsync(
            cancellationToken);

        return MapToDto(task);
    }

    private static TaskDto MapToDto(TaskItem task)
    {
        return new TaskDto
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