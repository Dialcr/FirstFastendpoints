using FastEndpoints;
using FastEndpoints.Security;
using FisrtFastEnpointsExample.Dto;

namespace FisrtFastEnpointsExample.Endpoints;

public class EndpointSearchCookie : EndpointWithoutRequest<SearchCookieResponse>
{
    public override void Configure()
    {
        Get("/api/searchCookie");
        AllowAnonymous();
    }

    public override async Task<SearchCookieResponse> HandleAsync(CancellationToken ct)
    {
        var a = HttpContext.Request.Cookies;
        var z = new SearchCookieResponse();
        z.CookieInfo = a.ToString();
        return z;
    }
}