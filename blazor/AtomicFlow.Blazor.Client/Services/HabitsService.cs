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

    public async Task CreateHabitAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient(nameof(HabitsService));

        // Testing
        var responseMessage = await httpClient.GetAsync("habits");
        
        string json = await responseMessage.Content.ReadAsStringAsync();

        var habitResponses = JsonSerializer.Deserialize<GetHabitsResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}