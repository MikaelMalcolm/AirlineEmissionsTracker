/** Interface for the OpenSky Token Service **/

using System.IdentityModel.Tokens.Jwt;

namespace Emissions.Services;

public interface IOpenSkyTokenService
{
    bool isAccessTokenValid();
    void setAccessToken(JwtSecurityToken accessToken);
    Task<bool> refreshAccessToken();
    Task<JwtSecurityToken> getOpenSkyJWT(); 
} 