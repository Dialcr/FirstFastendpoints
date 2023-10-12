using FastEndpoints;
using FisrtFastEnpointsExample.Dto;

namespace FisrtFastEnpointsExample.Endpoints;

//[FastEndpoints.HttpGet("/test/user/find/{intup}")]
public class NewFastendpoint : EndpointWithoutRequest<string>
{
    public override void Configure()
    {
        Get("/test/user/find/{intup}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var a = Route<string>("intup");
        await SendAsync("hola "+a);
    }
}