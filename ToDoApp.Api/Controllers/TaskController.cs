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
            try
            {
                var tasks = _taskService.GetAllTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            try
            {
                var task = _taskService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto task)
        {
            try
            {
                var id = task.Id ?? Guid.NewGuid();
                await _taskService.CreateTaskAsync(id, task.Title, task.CreatedAt ?? DateTime.UtcNow);
                return CreatedAtAction(nameof(GetTaskById), new { id = id }, task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            try
            {
                var task = _taskService.GetTaskByIdAsync(taskId);
                if (task == null)
                {
                    return NotFound($"Task with ID {taskId} not found.");
                }
                else
                {
                    await _taskService.DeleteTaskAsync(taskId);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, TaskDto task)
        {
            try
            {
                task.Id = id;
                var result = await _taskService.UpdateTaskAsync(id, task);

                return result > 0 ? Ok() : StatusCode(StatusCodes.Status304NotModified);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
