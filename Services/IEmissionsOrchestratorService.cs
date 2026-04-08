

using Emissions.Models.DTOs;

/** Interface for Emissions Orchestrator Service

**/
namespace Emissions.Services;

public interface IEmissionsOrchestratorService
{
    Task<OpenSkyStateVectorResponseDTO> GetEmissionsOverArea(OpenSkyStateVectorDTO openSkyVectorRequest);
}