using Microsoft.EntityFrameworkCore;
using TaskApp.Application.Interfaces;
using TaskApp.Domain.Entities;
using TaskApp.Infrastructure.Persistence;

namespace TaskApp.Infrastructure.Repositories;

public sealed class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Tasks
            .FirstOrDefaultAsync(
                task => task.Id == id,
                cancellationToken);
    }

    public async Task<IReadOnlyCollection<TaskItem>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Tasks
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(
        TaskItem task,
        CancellationToken cancellationToken = default)
    {
        await _context.Tasks.AddAsync(
            task,
            cancellationToken);
    }

    public Task DeleteAsync(
        TaskItem task,
        CancellationToken cancellationToken = default)
    {
        _context.Tasks.Remove(task);

        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}