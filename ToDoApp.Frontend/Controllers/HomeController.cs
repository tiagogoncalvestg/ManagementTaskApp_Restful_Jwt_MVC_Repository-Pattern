using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Frontend.Services;
using ToDoApp.Models;

namespace ToDoApp.Controllers;

public class HomeController : Controller
{
    private TaskService _taskService;
    public HomeController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var tasks = await _taskService.GetTasksAsync();

        return View(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTask(Guid taskId)
    {
        await _taskService.DeleteTaskAsync(taskId);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
