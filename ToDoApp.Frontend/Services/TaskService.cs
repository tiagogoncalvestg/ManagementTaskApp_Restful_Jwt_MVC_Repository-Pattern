using System;
using ToDoApp.Shared.Dtos;
using ToDoApp.Shared.Models;

namespace ToDoApp.Frontend.Services;

// TODO: IMPLEMENTAR AUTENTICAÇÃO JWT

// RESPONSÁVEL PELO CONSUMO DE API E MANIPULAÇÃO DE DADOS
public class TaskService
{
    HttpClient _httpClient;
    public TaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TaskDto>> GetTasksAsync()
    {
        var response = await _httpClient.GetAsync($"api/v1/task");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<TaskDto>>();
        }
        return new List<TaskDto>();
    }

    public async Task DeleteTaskAsync(Guid taskId, string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.DeleteAsync($"api/v1/task/{taskId}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to complete task");
        }
    }

    public async Task CreateTaskAsync(TaskDto task, string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.PostAsJsonAsync("api/v1/task", task);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to create task");
        }
    }

    public async Task<string> AuthAsync(Login login)
    {
        var response = await _httpClient.PostAsJsonAsync("api/v1/task/login", login);
        if (response.IsSuccessStatusCode)
        {
            var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
            return authResponse?.Token ?? throw new Exception("Token not found");
        }
        throw new Exception("Login failed");
    }

}

public record AuthResponse(string Token);