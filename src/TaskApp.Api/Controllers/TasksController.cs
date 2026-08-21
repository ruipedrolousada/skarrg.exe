using Microsoft.AspNetCore.Mvc;
using TaskApp.Application.DTOs;
using TaskApp.Application.Tasks.CancelTask;
using TaskApp.Application.Tasks.CompleteTask;
using TaskApp.Application.Tasks.CreateTask;
using TaskApp.Application.Tasks.GetTaskById;

namespace TaskApp.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public sealed class TasksController : ControllerBase
{
    private readonly CreateTaskUseCase _createTaskUseCase;
    private readonly GetTaskByIdUseCase _getTaskByIdUseCase;
    private readonly CompleteTaskUseCase _completeTaskUseCase;
    private readonly CancelTaskUseCase _cancelTaskUseCase;

    public TasksController(
        CreateTaskUseCase createTaskUseCase,
        GetTaskByIdUseCase getTaskByIdUseCase,
        CompleteTaskUseCase completeTaskUseCase,
        CancelTaskUseCase cancelTaskUseCase)
    {
        _createTaskUseCase = createTaskUseCase;
        _getTaskByIdUseCase = getTaskByIdUseCase;
        _completeTaskUseCase = completeTaskUseCase;
        _cancelTaskUseCase = cancelTaskUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<CreateTaskResult>> Create(
        CreateTaskRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _createTaskUseCase.ExecuteAsync(
            request,
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskDto>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _getTaskByIdUseCase.ExecuteAsync(
            id,
            cancellationToken);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("{id:guid}/complete")]
    public async Task<ActionResult<TaskDto>> Complete(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _completeTaskUseCase.ExecuteAsync(
            id,
            cancellationToken);

        return Ok(result);
    }

    [HttpPost("{id:guid}/cancel")]
    public async Task<IActionResult> Cancel(
        Guid id,
        CancellationToken cancellationToken)
    {
        await _cancelTaskUseCase.ExecuteAsync(
            id,
            cancellationToken);

        return NoContent();
    }
}

