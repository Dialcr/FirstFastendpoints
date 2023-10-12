
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FisrtFastEnpointsExample.Midellware;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class CustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context,RequestDelegate next)
    {
        // Do something before the request reaches the endpoint.
        //context.Response.ContentType = "text/plain";
        //await context.Response.WriteAsync("Hello from CustomMiddleware!");
        Console.WriteLine("Hello from CustomMiddleware!");
        await next(context);
        // Do something after the request has been processed by the endpoint.
    }

    
}

