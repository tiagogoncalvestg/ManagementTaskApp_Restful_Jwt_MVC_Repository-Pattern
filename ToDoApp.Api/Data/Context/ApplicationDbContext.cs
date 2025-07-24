using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Api.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // Initialization code here
    }
    
    public DbSet<Models.Task> Tasks { get; set; }
}
