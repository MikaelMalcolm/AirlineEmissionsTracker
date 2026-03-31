/** 
This service will handle all the auth related homework for accessing OpenSky

**/

namespace Emissions.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;

public class OpenSkyAuthService: IOpenSkyAuthService
{
      private JwtSecurityToken OpenSkyJWT;

      public OpenSkyAuthService()
      {

      }

      public Task<OpenSkyAuthResponseDTO> RefreshAuth()
      {
        
      }

      public bool isJWTValid()
      {
        
      }
}