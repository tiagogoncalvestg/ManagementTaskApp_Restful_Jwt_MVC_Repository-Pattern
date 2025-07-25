using System;
using ToDoApp.Shared.Dtos;

namespace ToDoApp.Api.Repositories.Interfaces;

public interface ITaskService
{
    public Task<int> CreateTaskAsync(Guid id, string title, DateTime createdAt);
    public Task<TaskDto> GetTaskByIdAsync(Guid id);
    public List<TaskDto> GetAllTasks();
    public Task<int> UpdateTaskAsync(Guid id, TaskDto task);
    public Task DeleteTaskAsync(Guid id);
}
