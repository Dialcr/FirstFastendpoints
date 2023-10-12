using Microsoft.IdentityModel.Tokens;

namespace FisrtFastEnpointsExample.Services;

public class AuthService 
{
    public bool CredentialsAreValid(string name, string password, CancellationToken ct)
    {
        if (name.IsNullOrEmpty() || password.IsNullOrEmpty())
        {
            return false;
        }

        return true;
    }
}