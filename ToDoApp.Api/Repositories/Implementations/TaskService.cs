using System;
using ToDoApp.Api.Data.Context;
using ToDoApp.Api.Repositories.Interfaces;
using ToDoApp.Shared.Dtos;

namespace ToDoApp.Api.Repositories.Implementations;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;
    public TaskService(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task CreateTaskAsync(Guid id, string title, DateTime createdAt)
    {
        _context.Tasks.Add(new Models.Task
        {
            Id = id,
            Title = title,
            CreatedAt = createdAt
        });
        return _context.SaveChangesAsync();
    }

    public Task DeleteTaskAsync(Guid id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if(task == null)
        {
            throw new KeyNotFoundException($"Task with ID {id} not found.");
        }
        else
        {
            _context.Tasks.Remove(task);
            return _context.SaveChangesAsync();
        }
    }

    public List<TaskDto> GetAllTasks()
    {
        List<TaskDto> taskDtos = new();

        var tasks = _context.Tasks.ToList();
        foreach (var task in tasks)
        {
            taskDtos.Add(new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                CreatedAt = task.CreatedAt
            });
        }
        return taskDtos;
    }

    public Task<TaskDto> GetTaskByIdAsync(Guid id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            throw new KeyNotFoundException($"Task with ID {id} not found.");
        }
        return Task.FromResult(new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            CreatedAt = task.CreatedAt
        });
    }

    public Task UpdateTaskAsync(Guid id, string title)
    {
        _context.Tasks.Update(new Models.Task
        {
            Id = id,
            Title = title,
            CreatedAt = DateTime.UtcNow
        });
        return _context.SaveChangesAsync();
    }
}
