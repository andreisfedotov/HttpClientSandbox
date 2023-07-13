using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<JokeService>();
var app = builder.Build();

app.MapGet("/", async (JokeService service) =>
{
    var joke = await service.GetJokeAsync();
    return Results.Ok(joke?.Value);
});

app.Run();

class Joke
{
    public string? Value { get; set; }
}

class JokeService
{
    private readonly HttpClient _httpClient;
    readonly JsonSerializerOptions Options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public JokeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.chucknorris.io/");
    }

    public async Task<Joke?> GetJokeAsync() =>
        await _httpClient.GetFromJsonAsync<Joke>("jokes/random", Options);
}
