using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
var app = builder.Build();

JsonSerializerOptions options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

app.MapGet("/", async (IHttpClientFactory httpClientFactory) =>
{
    HttpRequestMessage httpRequestMessage = new(HttpMethod.Get, "https://api.chucknorris.io/jokes/random");

    var httpClient = httpClientFactory.CreateClient();
    var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
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
