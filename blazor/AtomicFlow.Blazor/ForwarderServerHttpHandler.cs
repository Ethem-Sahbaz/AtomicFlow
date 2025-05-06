using Microsoft.Net.Http.Headers;

namespace AtomicFlow.Blazor;

public class ForwarderServerHttpHandler : HttpClientHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ForwarderServerHttpHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpContext? httpContext = _httpContextAccessor.HttpContext ?? 
                                   throw new InvalidOperationException("HttpContext is not set");

        IRequestCookieCollection cookies = httpContext.Request.Cookies;
        
        foreach (KeyValuePair<string, string> cookie in cookies)
        {
            string cookieHeaderValue = new CookieHeaderValue(cookie.Key, cookie.Value).ToString();
            
            request.Headers.Add("Cookie", cookieHeaderValue);
        }
        
        return base.SendAsync(request, cancellationToken);
    }
}