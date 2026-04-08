/* the Emissions Calculator Utlity Service 
Will be used to calculate:
- Great Circle Distance
- Elevation Change
- Emission Amount

Will implement the IEmissionsCalculatorService interface.

*/

namespace Emissions.Services;

public class EmissionsCalculatorService : IEmissionsCalculatorService
{
    public float CalculateGreatCircleDistance(float latitude1, float longitude1, float latitude2, float longitude2)
    {
        return 0.0f;
    }
    public float CalculateElevationChange(float latitude1, float longitude1, float latitude2, float longitude2)
    {
         return 0.0f;
    }
    public float CalculateEmissionAmount(float greatCircleDistance, float elevationChange)
    {
         return 0.0f;
    } 
}

