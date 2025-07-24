using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Shared.Dtos;
using ToDoApp.Api.Repositories.Interfaces;

namespace ToDoApp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDto task)
        {
            try
            {
                _taskService.CreateTaskAsync(task.Id ?? Guid.NewGuid(), task.Title, task.CreatedAt ?? DateTime.UtcNow);
                return StatusCode(StatusCodes.Status201Created, "Task created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            // This is a placeholder for the actual implementation
            return NoContent();
        }
    }
}
