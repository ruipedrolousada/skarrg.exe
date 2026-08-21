using TaskApp.Application.Interfaces;
using TaskApp.Domain;

namespace TaskApp.Application.Tasks.CreateTask;

public sealed class CreateTaskUseCase
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskUseCase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<CreateTaskResult> ExecuteAsync(
        CreateTaskRequest request,
        CancellationToken cancellationToken = default)
    {
        var task = new TaskItem(
            request.Title,
            request.Description,
            request.Priority,
            request.DueDate);

        await _taskRepository.AddAsync(task, cancellationToken);
        await _taskRepository.SaveChangesAsync(cancellationToken);

        return CreateTaskResult.FromTask(task);
    }
}
