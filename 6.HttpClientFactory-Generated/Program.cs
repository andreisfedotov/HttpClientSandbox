using Refit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRefitClient<IJokeClient>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri("https://api.chucknorris.io");
    });
var app = builder.Build();

app.MapGet("/", async (IJokeClient client) =>
{
    var joke = await client.GetJokeAsync();
    return Results.Ok(joke?.Value);
});

app.Run();

class Joke
{
    public string? Value { get; set; }
}

interface IJokeClient
{
    [Get("/jokes/random")]
    Task<Joke> GetJokeAsync();
}