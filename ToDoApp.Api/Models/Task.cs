using System;

namespace ToDoApp.Api.Models;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }  
    public DateTime CreatedAt { get; set; }
}
