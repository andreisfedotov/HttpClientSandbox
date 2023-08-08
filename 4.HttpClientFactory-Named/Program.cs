using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("Joke", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.chucknorris.io/");
});

#region Configuration
var app = builder.Build();

JsonSerializerOptions options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
#endregion

app.MapGet("/", async (IHttpClientFactory httpClientFactory) =>
{
    var httpClient = httpClientFactory.CreateClient("Joke");
    var httpResponseMessage = await httpClient.GetAsync("jokes/random");
    httpResponseMessage.EnsureSuccessStatusCode();

    var response = await httpResponseMessage.Content.ReadAsStringAsync();
    var joke = JsonSerializer.Deserialize<Joke>(response, options);
    return Results.Ok(joke?.Value);
});

app.Run();

class Joke
{
    public string? Value { get; set; }
}

