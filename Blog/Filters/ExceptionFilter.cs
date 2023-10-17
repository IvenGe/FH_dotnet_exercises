using System.Net;
using System.Runtime.ExceptionServices;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Blog.API.Filters;


public class ExceptionFilter : IAsyncExceptionFilter
{
    private static readonly JsonSerializerOptions SerializerOptions
        = new(JsonSerializerDefaults.Web);
    private readonly ILogger logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
        => this.logger = logger;

    protected virtual JsonSerializerOptions JsonSerializerOptions
        => SerializerOptions;

    public virtual Task OnExceptionAsync(ExceptionContext context)
    {
        HandleException<InvalidOperationException>(
            context,
            HttpStatusCode.NotFound,
            e => new { e.Message });

        return Task.CompletedTask;
    }

    protected void HandleException<T>(
        ExceptionContext context,
        HttpStatusCode httpStatusCode,
        Func<T, object?>? getResponse = null)
    {
        if (context.ExceptionHandled || context.Exception is not T ex)
            return;

        context.ExceptionHandled = true;
        context.HttpContext.Response.StatusCode = (int)httpStatusCode;

        logger.LogWarning(
            context.Exception,
            "Handling exception with status code {HttpStatusCode}",
            httpStatusCode);

        if (context.HttpContext.Response.HasStarted)
            return;

        var response = getResponse?.Invoke(ex);
        if (response != null)
        {
            context.HttpContext
                .Response
                .WriteAsJsonAsync(response, JsonSerializerOptions)
                .Wait();
        }
    }
}