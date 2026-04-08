using Microsoft.AspNetCore.Mvc;
using Emissions.Models;
using Emissions.Models.DTOs;
using Emissions.Services;

namespace Emissions.Controllers;

[Route("api/v1/Emissions")]
public class AirEmissionController : Controller
{
    private readonly IEmissionsOrchestratorService _emissionsOrchestrator;

    public AirEmissionController(IEmissionsOrchestratorService emissionsOrchestrator)
    {
        this._emissionsOrchestrator = emissionsOrchestrator;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        OpenSkyStateVectorDTO openSkyRequest = new OpenSkyStateVectorDTO
        {
            Lamin = 43.5655833,
            Lomin = -79.6763555,
            Lamax = 43.8754583,
            Lomax = -79.0993611, //
            Extended = true
        };

        OpenSkyStateVectorResponseDTO response = await this._emissionsOrchestrator.GetEmissionsOverArea(openSkyRequest);
        return Ok(response);
    }
}






















