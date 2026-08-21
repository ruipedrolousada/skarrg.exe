using Microsoft.AspNetCore.Mvc;
using TaskApp.Application.DTOs;
using TaskApp.Application.Interfaces;

namespace TaskApp.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public sealed class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create(
        CreateTaskRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _taskService.CreateAsync(
            request,
            cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}

