using System.Net.Http.Headers;

namespace HttpClientFactoryExample;

internal class HeadersHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return await base.SendAsync(request, cancellationToken);
    }
}
