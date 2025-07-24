using System;

namespace ToDoApp.Api.Repositories.Implementations;

public interface ITaskService
{
    public Task CreateTaskAsync(string title, DateTime createdAt);
    public Task<Models.Task> GetTaskByIdAsync(Guid id);
}
