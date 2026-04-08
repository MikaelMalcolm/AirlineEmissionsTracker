/** This is the service for grabbing data from the OpenSky API.
That's it really. LOL.
**/

using Emissions.Models.DTOs;

namespace Emissions.Services;

public interface IOpenSkyService
{
    Task<OpenSkyStateVectorResponseDTO> GetStateVectors(OpenSkyStateVectorDTO OpenSkyRequest);
}