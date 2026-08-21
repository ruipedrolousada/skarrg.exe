using TaskApp.Application.Interfaces;

namespace TaskApp.Application.Tasks.CancelTask;

public sealed class CancelTaskUseCase
{
    private readonly ITaskRepository _repository;

    public CancelTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var task = await _repository.GetByIdAsync(
            id,
            cancellationToken);

        if (task is null)
            throw new KeyNotFoundException(
                $"Task with id '{id}' was not found.");

        task.Cancel();

        await _repository.SaveChangesAsync(
            cancellationToken);
    }
}