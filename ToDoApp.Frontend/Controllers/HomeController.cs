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

    public async Task<IActionResult> Index()
    {
        var tasks = await _taskService.GetTasksAsync();

        return View(tasks);
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
