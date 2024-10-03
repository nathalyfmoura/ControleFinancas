using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

public class MiddlewareDeTratamentoDeExcecao
{
    private readonly RequestDelegate _next;
    private readonly ILogger<MiddlewareDeTratamentoDeExcecao> _logger;

    public MiddlewareDeTratamentoDeExcecao(RequestDelegate next, ILogger<MiddlewareDeTratamentoDeExcecao> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await TratarExcecaoAsync(context, ex);
        }
    }

    private Task TratarExcecaoAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, "Ocorreu uma exceção: {Message}", ex.Message);

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        return context.Response.WriteAsync(new
        {
            StatusCode = context.Response.StatusCode,
            Message = "Ocorreu um erro interno no servidor."
        }.ToString());
    }
}
