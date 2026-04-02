/** this is the service for interacting with the OpenSky API
Implements the IOpenSkyService Interface
**/

namespace Emissions.Services;

public class OpenSkyService: IOpenSkyService
{

    private readonly IOpenSkyTokenService _tokenService;
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;
    private string _baseURL;

    
    public OpenSkyService(IConfiguration config, IOpenSkyTokenService tokenService, HttpClient httpClient)
    {
        this._config = config;
        this._tokenService = tokenService;
        this._httpClient = httpClient;
        this._httpClient.BaseAddress = new Uri(this._config["ExternalURLs:OpenSkyAPI"] );

    }

    public Task<OpenSkyStateVectorResponseDTO> GetStateVectors(OpenSkyStateVectorDTO OpenSkyRequest)
    {
        var accessToken = this._tokenService.getOpenSkyJWT();
        this._httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.ToString());

        var builder = new UriBuilder(this._config["ExternalURLs:OpenSkyAPI"] + "states/all");
        var query = HttpUtility.ParseQueryString(builder.Query);

        query["lamin"] = "123";
        query["lomin"] = "books";
        query["lamax"] = "123";
        query["lomax"] = "books";
        query["icao24"] = "";
        query["time"] = "";
        query["extended"] = "";


        builder.Query = query.ToString();
        string url = builder.ToString();


        var response = await this._httpClient.GetFromJSONAsync<OpenSkyStateVectorResponseDTO>(url);
        
    }


}