/** this is the service for interacting with the OpenSky API
Implements the IOpenSkyService Interface
**/

namespace Emissions.Services;

public class OpenSkyService: IOpenSkyService
{
    public Task<OpenSkyStateVectorResponseDTO> GetStateVectors(OpenSkyStateVectorDTO OpenSkyRequest)
    {

    }
}