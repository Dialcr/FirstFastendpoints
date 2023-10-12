using System.Security.Claims;
using FastEndpoints;
using FastEndpoints.Security;
using FisrtFastEnpointsExample.Services;


namespace FisrtFastEnpointsExample.Login;

public class UserLoginEndpoint : Endpoint<LoginRequest>
{
    private readonly AuthService _authService;

    public UserLoginEndpoint(AuthService authService)
    {
        _authService = authService;
    }
    public override void Configure()
    {
        Post("/api/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        if (_authService.CredentialsAreValid(req.Username, req.Password, ct))
        {
            /*var jwtToken = JWTBearer.CreateToken(
                signingKey: "TokenSigningKey",
                expireAt: DateTime.UtcNow.AddDays(1),
                priviledges: u =>
                {
                    u.Roles.Add("Manager");
                    u.Permissions.AddRange(new[] { "ManageUsers", "ManageInventory" });
                    u.Claims.Add(new("UserName", req.Username));
                    u["UserID"] = "001"; //indexer based claim setting
                });*/
            

            var claimsList = new List<Claim>();
            claimsList.Add(new Claim("UserName", req.Username));
            claimsList.Add(new Claim("UserID", "001" ));
            
            var jwtToken = JWTBearer.CreateToken(
                signingKey: "TokenSigningKeTestFastEndpointEncoding",
                expireAt: DateTime.UtcNow.AddDays(1),
                roles: new List<string> { "Manager" },
                permissions: new[] { "ManageUsers", "ManageInventory" },
                claims: claimsList
                
                );
            await SendAsync(new
            {
                Username = req.Username,
                Token = jwtToken
            });
        }
        else
        {
            ThrowError("The supplied credentials are invalid!");
        }
    }
}