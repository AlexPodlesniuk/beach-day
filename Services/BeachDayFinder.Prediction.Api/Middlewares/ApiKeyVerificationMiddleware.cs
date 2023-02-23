namespace BeachDayFinder.Prediction.Api.Middlewares;

public class ApiKeyVerificationMiddleware
{
    private const string ApiKey = "X-Api-Key";
    
    private readonly RequestDelegate _next;

    public ApiKeyVerificationMiddleware(RequestDelegate next) =>  _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var apiKey = context.Request.Headers[ApiKey];

        if (string.IsNullOrEmpty(apiKey))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync($"{ApiKey} is missing");
            return;
        }
        
        await _next(context);
    }
}