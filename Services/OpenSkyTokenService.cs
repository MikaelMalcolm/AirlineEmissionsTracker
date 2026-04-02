/** Implementation of the OpenSky Token Service 
This manages the state of the OpenSky Access Token -- it will be a singeton
singleton pattern is used to ensure that only one instance of the class exists
and that it is used throughout the application.
Request will check the state so they know if they need to refresh the token.
We will need to handle concurrency -- if the token is being refreshed, another request should not be able to use the token until it is refreshed.
Might need to use some semaphores to ensure that only one request can refresh the token at a time.
We will need to handle the case where the token is expired -- we will need to refresh the token.
We will need to handle the case where the token is not valid -- we will need to refresh the token.
We will need to handle the case where the token is not valid -- we will need to refresh the token.
 **/

namespace Emissions.Services;

using System.IdentityModel.Tokens.Jwt;

public class OpenSkyTokenService : IOpenSkyTokenService
{   
    private readonly IConfiguration _config;
    private JwtSecurityToken OpenSkyJWT;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private readonly IHttpClientFactory _httpClientFactory;
    
    public OpenSkyTokenService(IConfiguration config, IHttpClientFactory httpClientFactory)
    {
        this._config = config;
        this.accessToken = string.Empty;
        this.OpenSkyJWT = null;
        this._httpClientFactory = httpClientFactory;
    }

    public bool isAccessTokenValid()
    { 
        if (this.OpenSkyJWT == null)
        {
            return false;
        }
        if (this.OpenSkyJWT.ValidTo < DateTime.UtcNow)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> refreshAccessToken(IOpenSkyAuthService openSkyAuthService)
    {
        var client = this._httpClientFactory.CreateClient();  //Create the HTTP client -- did not inject a typed Client becuase this class is a singleton

        // Set the content type and the content of the request
        client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" },
            { "client_id", this._config["OpenSky:ClientID"] },
            { "client_secret", this._config["OpenSky:ClientSecret"] }
        });
        // Send the request
        var response = await client.PostAsync(this._config["ExternalURLs:OpenSkyAuth"] + "auth/realms/opensky-network/protocol/openid-connect/token", content); 
        // Handle the response -- if the response is successful, we will return the token
        if(response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();  // Read the response content
            var jwt = new JwtSecurityToken(responseContent);  // Create the JWT token
            this.setAccessToken(jwt);  // Set the token in the OpenSkyTokenService
            return true;
        }       
        return false;  // Return false if the response is not successful
    }

    private void setAccessToken(JwtSecurityToken accessToken)
    {
        this.OpenSkyJWT = accessToken;
    }

    public JwtSecurityToken getOpenSkyJWT()
    {
        if(!this.isAccessTokenValid())
        {
          
            bool success = await this.refreshAccessToken(openSkyAuthService);
            if(success)
            {
                return this.OpenSkyJWT;
            }
            else
            {
                return null;
            }
           
        
        }
        return this.OpenSkyJWT;
    }

}