using Microsoft.EntityFrameworkCore;
using TaskApp.Application.Interfaces;
using TaskApp.Application.Tasks.CompleteTask;
using TaskApp.Application.Tasks.CreateTask;
using TaskApp.Application.Tasks.GetTaskById;
using TaskApp.Infrastructure.Persistence;
using TaskApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<CreateTaskUseCase>();
builder.Services.AddScoped<GetTaskByIdUseCase>();
builder.Services.AddScoped<CompleteTaskUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();