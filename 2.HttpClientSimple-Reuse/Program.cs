internal class Program
{
    private static readonly HttpClient Client = new(new HttpClientHandler());
    private static async Task Main()
    {
        for (int i = 0; i < 5; i++)
        {
            var result = await Client.GetAsync("https://api.chucknorris.io/jokes/random");
            Console.WriteLine($"{i + 1}: {result.StatusCode}");
        }
    }
}