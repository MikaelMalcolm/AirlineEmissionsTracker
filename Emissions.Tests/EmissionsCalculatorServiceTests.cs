using Emissions.Services;
using Xunit;

namespace Emissions.Tests;

public class EmissionsCalculatorServiceTests
{
    private readonly EmissionsCalculatorService _sut = new();

    [Fact]
    public void CalculateGreatCircleDistance_SamePoint_ReturnsZero()
    {
        float d = _sut.CalculateGreatCircleDistance(43.65, -79.38, 43.65, -79.38);

        Assert.True(Math.Abs(d) < 0.5f, $"Expected ~0 m, got {d}");
    }

    [Fact]
    public void CalculateGreatCircleDistance_OneDegreeLatitude_Approximately111Km()
    {
        // ~ (π/180) * Earth radius meters
        const double expectedMeters = Math.PI / 180.0 * 6371000.0;

        float d = _sut.CalculateGreatCircleDistance(0, 0, 1, 0);

        Assert.InRange(d, (float)(expectedMeters * 0.999), (float)(expectedMeters * 1.001));
    }

    [Fact]
    public void CalculateGreatCircleDistance_OneDegreeLongitudeAtEquator_Approximately111Km()
    {
        const double expectedMeters = Math.PI / 180.0 * 6371000.0;

        float d = _sut.CalculateGreatCircleDistance(0, 0, 0, 1);

        Assert.InRange(d, (float)(expectedMeters * 0.999), (float)(expectedMeters * 1.001));
    }

    [Fact]
    public void CalculateGreatCircleDistance_ParisToLondon_IsRoughly340To350Km()
    {
        // Approximate reference distance for regression testing (Haversine, WGS84 mean radius used in service).
        float d = _sut.CalculateGreatCircleDistance(48.8566, 2.3522, 51.5074, -0.1278);

        Assert.InRange(d, 330_000f, 360_000f);
    }

    [Theory]
    [InlineData(10_000, 10_500, 500)]
    [InlineData(12_000, 11_000, -1000)]
    [InlineData(8000, 8000, 0)]
    public void CalculateElevationChange_ReturnsEndMinusStart(
        double startMeters,
        double endMeters,
        double expectedDelta)
    {
        float delta = _sut.CalculateElevationChange(startMeters, endMeters);

        Assert.Equal(expectedDelta, (double)delta, 5);
    }

    [Fact]
    public void CalculateEmissionAmount_CurrentImplementation_ReturnsZero()
    {
        // Update this test when CalculateEmissionAmount is implemented.
        float amount = _sut.CalculateEmissionAmount(1000, 500);

        Assert.Equal(0f, amount);
    }
}
