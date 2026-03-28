/* Interface for the Emissions Calculator Utlity Service 
Will be used to calculate:
- Great Circle Distance
- Elevation Change
- Emission Amount

*/

namespace Emissions.Services;

public interface IEmissionsCalculatorService
{

    float CalculateGreatCircleDistance(float latitude1, float longitude1, float latitude2, float longitude2);
    float CalculateElevationChange(float latitude1, float longitude1, float latitude2, float longitude2);
    float CalculateEmissionAmount(float greatCircleDistance, float elevationChange);
}