using System;
using ToDoApp.Shared.Dtos;

namespace ToDoApp.Frontend.Services;

// TODO: IMPLEMENTAR AUTENTICAÇÃO JWT

// RESPONSÁVEL PELO CONSUMO DE API E MANIPULAÇÃO DE DADOS
public class TaskService
{

    // string BASEURL = "http://localhost:5040/";

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

    public async Task DeleteTaskAsync(Guid taskId)
    {
        var response = await _httpClient.DeleteAsync($"api/v1/task/{taskId}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to complete task");
        }
    }

}