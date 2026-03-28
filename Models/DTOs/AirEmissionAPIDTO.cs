namespace Emissions.Models.DTOs;

/**
These DTOs are used to communicate with the Air Emission API.
The frontend will request the Emissions from the API for a geographical area over a timeperiod (max 1 hour)

**/
public record AEmitRequestDTO
{
    public float? lamin { get; set; }
    public float? lomin { get; set; }
    public float? lamax { get; set; }
    public float? lomax { get; set; }
    public int? timeperiod { get; set; } // in minutes
}

public record AEmitResponseDTO
{
    public float? TotalEmissions { get; set; }
    public List<EmissionsPerTransponderDTO> Emissions { get; set; }
}

public record EmissionsPerTransponderDTO
{
    public TransponderInfoDTO TransponderInfo { get; set; }
    public float? GreatCircleDistance { get; set; }
    public float? ElevationChange { get; set; }
    public float? EmissionAmount { get; set; }
}

public record TransponderInfoDTO
{
    public string? TransponderID { get; set; }
    public string? CallSign{ get; set; }
    public string? OriginCountry { get; set; }
    public string? AircraftType { get; set; }

}


public record AEmitResponseErrorDTO
{
    public string? ErrorMessage { get; set; }
    public string? ErrorCode { get; set; }
}



