using TaskApp.Application.DTOs;
using TaskApp.Application.Interfaces;

namespace TaskApp.Application.Tasks.CompleteTask;

public sealed class CompleteTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public CompleteTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskDto> ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var task = await _taskRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new InvalidOperationException($"Task with id '{id}' was not found.");

        task.Complete();

        await _taskRepository.SaveChangesAsync(cancellationToken);

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
