


using FastEndpoints.Security;

namespace FisrtFastEnpointsExample.Midellware;

public class CookieMiddellware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        CookieAuth.SignInAsync(u =>
        {
            u.Roles.Add("Admin");
            u.Permissions.AddRange(new[] { "Create_Item", "Delete_Item" });
            u.Claims.Add(new("Address", "123 Street"));

            //indexer based claim setting
            u["Email"] = "abc@def.com";
            u["Department"] = "Administration";
        });
        await next(context);
    }
}