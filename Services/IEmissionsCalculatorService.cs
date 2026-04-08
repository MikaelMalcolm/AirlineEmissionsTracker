/* Interface for the Emissions Calculator Utlity Service 
Will be used to calculate:
- Great Circle Distance
- Altitude delta flown (end − start, meters)
- Emission Amount

*/

namespace Emissions.Services;

public interface IEmissionsCalculatorService
{

    float CalculateGreatCircleDistance(double latitude1, double longitude1, double latitude2, double longitude2);
    /// <summary>Altitude change flown in meters: <paramref name="altitudeMetersEnd"/> − <paramref name="altitudeMetersStart"/>.</summary>
    float CalculateElevationChange(double altitudeMetersStart, double altitudeMetersEnd);
    float CalculateEmissionAmount(double greatCircleDistance, double elevationChange);
}