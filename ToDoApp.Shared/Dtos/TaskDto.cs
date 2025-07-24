using System;

namespace ToDoApp.Shared.Dtos;

public class TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }  
    public DateTime CreatedAt { get; set; }
}
