using System.Net.Http.Json;
using System.Text.Json;
using AtomicFlow.Contracts.Habits;

namespace AtomicFlow.Blazor.Client.Services;

public sealed class HabitsService : IHabitService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HabitsService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GetHabitsResponse?> CreateHabitAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient(nameof(HabitsService));
        
        var responseMessage = await httpClient.GetAsync("habits");

        if (!responseMessage.IsSuccessStatusCode)
        {
            return null;
        }
        
        string json = await responseMessage.Content.ReadAsStringAsync();

        var habitResponses = JsonSerializer.Deserialize<GetHabitsResponse>(
            json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        return habitResponses;
    }
}