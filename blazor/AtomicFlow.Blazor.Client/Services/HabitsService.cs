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
        HttpResponseMessage responseMessage = await httpClient.PostAsync("habits", null);
        
        string json = await responseMessage.Content.ReadAsStringAsync();
    }
}