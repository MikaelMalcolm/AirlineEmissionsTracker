

using Emissions.Models.DTOs;

/** This Service will contain the main "business logic" for 
- Taking a request from the client
- fetching OpenSky data
- calculating Emissions
- Storing Historical data 
- return formatted result to Client
- pretty much will be calling "sub services" to get the job done

**/
namespace Emissions.Services;

public class EmissionsOrchestratorService: IEmissionsOrchestratorService
{
    private readonly IOpenSkyService _openSkyService;
    private readonly IEmissionsCalculatorService _calculatorService;

    public EmissionsOrchestratorService(IOpenSkyService openSkyService, IEmissionsCalculatorService calculatorService)
    {

        this._openSkyService = openSkyService;
        this._calculatorService = calculatorService;
    }

    public async Task<OpenSkyStateVectorResponseDTO> GetEmissionsOverArea(OpenSkyStateVectorDTO openSkyRequest)
    {
         return await _openSkyService.GetStateVectors(openSkyRequest);
    }
}
