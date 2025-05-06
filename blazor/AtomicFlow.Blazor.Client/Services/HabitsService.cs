namespace AtomicFlow.Blazor.Client.Services;

public sealed class HabitsService : IHabitService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HabitsService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task GetHabitsAsync()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient(nameof(HabitsService));

        HttpResponseMessage responseMessage = await httpClient.GetAsync("/habits");
        
        string json = await responseMessage.Content.ReadAsStringAsync();
    }
}

public interface IHabitService
{
    Task GetHabitsAsync();
}