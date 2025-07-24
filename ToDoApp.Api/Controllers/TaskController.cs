using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTasks()
        {
            // This is a placeholder for the actual implementation
            return Ok(new { Message = "List of tasks" });
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] string task)
        {
            // This is a placeholder for the actual implementation
            return CreatedAtAction(nameof(GetTasks), new { Message = "Task created", Task = task });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            // This is a placeholder for the actual implementation
            return NoContent();
        }
    }
}
