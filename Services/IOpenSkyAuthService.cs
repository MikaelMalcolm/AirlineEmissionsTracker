/** 
This service will handle all the auth related homework for accessing OpenSky

**/

namespace Emissions.Services;

public interface IOpenSkyAuthService
{
    Task<OpenSkyAuthResponseDTO> RefreshAuth();
    bool isJWTValid();
}