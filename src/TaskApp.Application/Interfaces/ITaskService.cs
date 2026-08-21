using TaskApp.Application.DTOs;

namespace TaskApp.Application.Interfaces;

public interface ITaskService
{
    Task<TaskDto> CreateAsync(
        CreateTaskRequest request,
        CancellationToken cancellationToken = default);
}