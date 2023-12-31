﻿internal class Program
{
    private static readonly HttpClient _httpClient = new(new HttpClientHandler());
    private static async Task Main()
    {
        for (int i = 0; i < 5; i++)
        {
            var result = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");
            Console.WriteLine($"{i + 1}: {result.StatusCode}");
        }
    }
}