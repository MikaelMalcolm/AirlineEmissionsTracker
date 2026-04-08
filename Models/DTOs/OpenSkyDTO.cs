/** DTO for the OpenSky Rest API
**/

using System.Text.Json.Serialization;

namespace Emissions.Models.DTOs;

#region State Vectors API
public record OpenSkyStateVectorDTO
{
    public string? Icao24 { get; init; }
    public int? Time { get; init; }
    public double? Lamin { get; init; }
    public double? Lomin { get; init; }
    public double? Lamax { get; init; }
    public double? Lomax { get; init; }
    public bool? Extended { get; init; }
}

public record OpenSkyStateVectorResponseDTO
{
    public int time { get; init; }
    public List<OpenSkyStateVectorDTO> states { get; init; } = [];
}


public record OpenSkyVectorArrayDTO
{
    public List<OpenSkyVectorInfoDTO> vectors { get; init; } = [];
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
    public double? Longitude { get; init; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; init; }

    [JsonPropertyName("baro_altitude")]
    public double? BaroAltitude { get; init; }

    [JsonPropertyName("on_ground")]
    public bool OnGround { get; init; }

    [JsonPropertyName("velocity")]
    public double? Velocity { get; init; }

    [JsonPropertyName("true_track")]
    public double? TrueTrack { get; init; }

    [JsonPropertyName("vertical_rate")]
    public double? VerticalRate { get; init; }

    [JsonPropertyName("sensors")]
    public int[]? Sensors { get; init; }

    [JsonPropertyName("geo_altitude")]
    public double? GeoAltitude { get; init; }

    [JsonPropertyName("squawk")]
    public string? Squawk { get; init; }

    [JsonPropertyName("spi")]
    public bool Spi { get; init; }

    [JsonPropertyName("position_source")]
    public int PositionSource { get; init; }

    [JsonPropertyName("category")]
    public int Category { get; init; }
}

#endregion


#region Auth API
public record OpenSkyAuthDTO
{
    public string? icao24 { get; init; }
    public int? time { get; init; }
    public double? lamin { get; init; }
    public double? lomin { get; init; }
    public double? lamax { get; init; }
    public double? lomax { get; init; }
}



public record OpenSkyAuthResponseDTO
{
    public string? icao24 { get; init; }
    public int? time { get; init; }
    public double? lamin { get; init; }
    public double? lomin { get; init; }
    public double? lamax { get; init; }
    public double? lomax { get; init; }
}

#endregion