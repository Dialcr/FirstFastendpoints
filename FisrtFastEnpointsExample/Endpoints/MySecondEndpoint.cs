using FastEndpoints;
using FisrtFastEnpointsExample.Dto;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FisrtFastEnpointsExample.Endpoints;

public class MySecondEndpoint : Endpoint<MyRequest, 
    Results<Ok<MyResponse>, 
        NotFound, 
        ProblemDetails>>
{
    public override void Configure()
    {
        Post("/api/second/endpoint");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<MyResponse>, NotFound, ProblemDetails>> ExecuteAsync(
        MyRequest req, CancellationToken ct)
    {
        await Task.CompletedTask; //simulate async work

        if (req.Id == 0) //condition for a not found response
        {
            return TypedResults.NotFound();
        }

        if (req.Id == 1) //condition for a problem details response
        {
            AddError(r => r.Id, "value has to be greater than 1");
            return new FastEndpoints.ProblemDetails(ValidationFailures);
        }

        // 200 ok response with a DTO
        return TypedResults.Ok(new MyResponse
        {
            RequestedId = req.Id
        });
    }
}