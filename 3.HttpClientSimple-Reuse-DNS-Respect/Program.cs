internal class Program
{
    private static readonly HttpClient _httpClient = new(new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(1)
    });

    private static async Task Main()
    {
        for (int i = 0; i < 5; i++)
        {
            var result = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
            Console.WriteLine($"{i + 1}: {result.StatusCode}");
        }
    }
}

