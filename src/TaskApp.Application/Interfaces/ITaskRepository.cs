using TaskApp.Domain.Entities;

namespace TaskApp.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TaskItem>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task AddAsync(
        TaskItem task,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        TaskItem task,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync(
        CancellationToken cancellationToken = default);
}