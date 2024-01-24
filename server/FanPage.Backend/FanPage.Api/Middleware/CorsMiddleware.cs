namespace FanPage.Api.Middleware;

public class CorsMiddleware
{
    private readonly RequestDelegate _next;

    public CorsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var headers = context.Request.Headers;
        foreach (var header in headers)
        {
            Console.WriteLine($"{header.Key}: {header.Value}");
        }
        
        await _next(context);
    }
}