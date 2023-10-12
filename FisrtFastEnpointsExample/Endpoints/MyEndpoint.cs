using FastEndpoints;
using FisrtFastEnpointsExample.Dto;
using Microsoft.AspNetCore.Authorization;

namespace FisrtFastEnpointsExample.Endpoints;

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    [Authorize]
    public override void Configure()
    {
        Post("/api/user/create");
        
    }

    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {
        await SendAsync(new()
        {
            FullName = req.FirstName + " " + req.LastName,
            IsOver18 = req.Age > 18
        });
    }
}