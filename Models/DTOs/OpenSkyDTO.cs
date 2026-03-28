/** DTO for the OpenSky API.
**/

using System.Text.Json.Serialization;

namespace Emissions.Models.DTOs;

public record OpenSkyStateVectorDTO
{
    public string? icao24 { get; set; }
    public int? time { get; set; }
    public float? lamin { get; set; }
    public float? lomin { get; set; }
    public float? lamax { get; set; }
    public float? lomax { get; set; }
}

public record OpenSkyStateVectorResponseDTO
{
    public int time { get; set; }
    public List<OpenSkyStateVectorDTO> states { get; set; }
}


public record OpenSkyVectorArrayDTO
{
    public List<OpenSkyVectorInfoDTO> vectors { get; set; }
}

/// <summary>One OpenSky state vector row (indices 0–17). See OpenSky REST API state vector table.</summary>
public record OpenSkyVectorInfoDTO
{
    [JsonPropertyName("icao24")]
    public string Icao24 { get; init; } = "";

    [JsonPropertyName("callsign")]
    public string? Callsign { get; init; }

    [JsonPropertyName("origin_country")]
    public string OriginCountry { get; init; } = "";

    [JsonPropertyName("time_position")]
    public int? TimePosition { get; init; }

    [JsonPropertyName("last_contact")]
    public int LastContact { get; init; }

    [JsonPropertyName("longitude")]
    public float? Longitude { get; init; }

    [JsonPropertyName("latitude")]
    public float? Latitude { get; init; }

    [JsonPropertyName("baro_altitude")]
    public float? BaroAltitude { get; init; }

    [JsonPropertyName("on_ground")]
    public bool OnGround { get; init; }

    [JsonPropertyName("velocity")]
    public float? Velocity { get; init; }

    [JsonPropertyName("true_track")]
    public float? TrueTrack { get; init; }

    [JsonPropertyName("vertical_rate")]
    public float? VerticalRate { get; init; }

    [JsonPropertyName("sensors")]
    public int[]? Sensors { get; init; }

    [JsonPropertyName("geo_altitude")]
    public float? GeoAltitude { get; init; }

    [JsonPropertyName("squawk")]
    public string? Squawk { get; init; }

    [JsonPropertyName("spi")]
    public bool Spi { get; init; }

    [JsonPropertyName("position_source")]
    public int PositionSource { get; init; }

    [JsonPropertyName("category")]
    public int Category { get; init; }
}
