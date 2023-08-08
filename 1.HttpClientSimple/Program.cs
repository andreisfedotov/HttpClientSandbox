for (int i = 0; i < 5; i++)
{
    using var client = new HttpClient();
    var result = await client.GetAsync("https://api.chucknorris.io/jokes/random");
    Console.WriteLine($"{i + 1}: {result.StatusCode}");
}

