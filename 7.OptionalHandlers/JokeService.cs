using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace HttpClientFactoryExample;

internal class JokeService
{
    private readonly IHttpClientFactory _factory;
    readonly JsonSerializerOptions Options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public JokeService(IHttpClientFactory factory) => _factory = factory;

    public async Task<Joke?> GetJokeAsync()
    {
        var client = _factory.CreateClient("joke");
        var joke = await client.GetFromJsonAsync<Joke>("jokes/random", Options);
        return joke;
    }
}
