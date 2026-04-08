/** this is the service for interacting with the OpenSky API
Implements the IOpenSkyService Interface
**/

using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Emissions.Models.DTOs;
using Microsoft.AspNetCore.WebUtilities;

namespace Emissions.Services;

public class OpenSkyService: IOpenSkyService
{

    private readonly IOpenSkyTokenService _tokenService;
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;
    
    public OpenSkyService(IConfiguration config, IOpenSkyTokenService tokenService, HttpClient httpClient)
    {
        this._config = config;
        this._tokenService = tokenService;
        this._httpClient = httpClient;
        var baseUrl = this._config["ExternalURLs:OpenSkyAPI"];
        if (!string.IsNullOrEmpty(baseUrl))
            this._httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<OpenSkyStateVectorResponseDTO> GetStateVectors(OpenSkyStateVectorDTO openSkyRequest)
    {
        var accessToken = await this._tokenService.getOpenSkyJWT();
        if (accessToken?.RawData is null)
            throw new InvalidOperationException("OpenSky access token is not available.");

        var basePath = "states/all";
        var query = new Dictionary<string, string?>();
        if (openSkyRequest.Lamin.HasValue)
            query["lamin"] = openSkyRequest.Lamin.Value.ToString(CultureInfo.InvariantCulture);
        if (openSkyRequest.Lomin.HasValue)
            query["lomin"] = openSkyRequest.Lomin.Value.ToString(CultureInfo.InvariantCulture);
        if (openSkyRequest.Lamax.HasValue)
            query["lamax"] = openSkyRequest.Lamax.Value.ToString(CultureInfo.InvariantCulture);
        if (openSkyRequest.Lomax.HasValue)
            query["lomax"] = openSkyRequest.Lomax.Value.ToString(CultureInfo.InvariantCulture);
        if (!string.IsNullOrEmpty(openSkyRequest.Icao24))
            query["icao24"] = openSkyRequest.Icao24;
        if (openSkyRequest.Time.HasValue)
            query["time"] = openSkyRequest.Time.Value.ToString(CultureInfo.InvariantCulture);
        if (openSkyRequest.Extended.HasValue)
            query["extended"] = openSkyRequest.Extended.Value ? "1" : "0";

        var relative = QueryHelpers.AddQueryString(basePath, query);
        var request = new HttpRequestMessage(HttpMethod.Get, relative);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.RawData);

        var response = await this._httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string rawResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Raw Response: + " + rawResponse);
        var result = await response.Content.ReadFromJsonAsync<OpenSkyStateVectorResponseDTO>();
        return result ?? throw new InvalidOperationException("OpenSky returned an empty body.");
    }


}
