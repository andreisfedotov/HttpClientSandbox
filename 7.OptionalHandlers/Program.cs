using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OptionalHandlers;

var builder = Host.CreateApplicationBuilder(args);
ConfigureServices(builder.Services);
var app = builder.Build();
app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient("joke", c =>
    {
        c.BaseAddress = new Uri("https://api.chucknorris.io/");
    })
    .ConfigureHttpClient(c =>
    {
        c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Example");
    })
    .AddHttpMessageHandler<HeadersHandler>();

    services.AddTransient<HeadersHandler>();
}
