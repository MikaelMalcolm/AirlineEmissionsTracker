/** This is the service for grabbing data from the OpenSky API.
That's it really. LOL.
**/

using Emissions.Models.DTOs;

namespace Emissions.Services;

public interface IOpenSkyService
{
    Task<OpenSkyStateVectorResponseDTO> GetStateVectors(OpenSkyStateVectorDTO OpenSkyRequest);
    Task<List<OpenSkyStateVectorResponseDTO> GetBatchStateVectors(OpenSkyStateVectorDTO OpenSkyRequest, int minutesInPast = 60, int intervalLength = 15);

}