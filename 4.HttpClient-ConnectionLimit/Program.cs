var handler = new HttpClientHandler()
{
   MaxConnectionsPerServer = 2
};

var client = new HttpClient(handler);
var tasks = new List<Task>();

for (var i = 0; i < 10; i++)
{
    tasks.Add(SendRequest(client, "https://hub.dummyapis.com/delay?seconds=5"));
}

Task.WaitAll(tasks.ToArray());

async Task SendRequest(HttpClient client, string url)
{
    var response = await client.GetAsync(url);
    Console.WriteLine($"Received {response.StatusCode} from {url}");
}