/** Interface for the OpenSky Token Service **/


namespace Emissions.Services;

public interface IOpenSkyTokenService
{
    bool isAccessTokenValid();
    void setAccessToken(JwtSecurityToken accessToken);
    Task<bool> refreshAccessToken(IOpenSkyAuthService openSkyAuthService);
    JwtSecurityToken getOpenSkyJWT();
}