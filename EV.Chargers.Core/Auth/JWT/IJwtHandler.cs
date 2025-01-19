using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EV.Chargers.Core.Auth.User;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace EV.Chargers.Core.Auth.JWT
{
    public interface IJwtHandler
    {
        JwtSecurityToken ValidateJwtToken(string token);
        JsonWebToken Create(List<Claim> PreClaims);
        TokenContext CreateWithRefreshToken(ActiveContext activeContext);
        JsonWebToken CleanCreate(ActiveContext activeContext);
        string? GetClaim(string token, string claimType);
        JsonWebToken Create(ActiveContext activeContext, bool UsingCache = true);
    }
}
