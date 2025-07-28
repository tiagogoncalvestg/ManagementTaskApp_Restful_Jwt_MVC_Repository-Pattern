using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Frontend.Services;
using ToDoApp.Models;
using ToDoApp.Shared.Models;

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
        var login = new Login
        {
            Email = "teste@teste.com",
            Password = "123456"
        };

        // SIMULA USUÁRIO LOGADO
        var token = await _taskService.AuthAsync(login);

        await _taskService.DeleteTaskAsync(taskId, token);
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