/* the Emissions Calculator Utlity Service 
Will be used to calculate:
- Great Circle Distance
- Altitude delta flown (end − start, meters)
- Emission Amount

Will implement the IEmissionsCalculatorService interface.

*/

namespace Emissions.Services;

public class EmissionsCalculatorService : IEmissionsCalculatorService
{
    private const double EarthRadiusMeters = 6371000.0;

    public float CalculateGreatCircleDistance(double latitude1, double longitude1, double latitude2, double longitude2)
    {
        double lat1Rad = DegreesToRadians(latitude1);
        double lon1Rad = DegreesToRadians(longitude1);
        double lat2Rad = DegreesToRadians(latitude2);
        double lon2Rad = DegreesToRadians(longitude2);

        double deltaLat = lat2Rad - lat1Rad;
        double deltaLon = lon2Rad - lon1Rad;

        // Haversine: stable for short and long distances.
        double a =
            Math.Sin(deltaLat / 2.0) * Math.Sin(deltaLat / 2.0) +
            Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
            Math.Sin(deltaLon / 2.0) * Math.Sin(deltaLon / 2.0);

        double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));
        double distanceMeters = EarthRadiusMeters * c;

        return (float)distanceMeters;
    }
    public float CalculateElevationChange(double altitudeMetersStart, double altitudeMetersEnd)
    {
        return (float)(altitudeMetersEnd - altitudeMetersStart);
    }
    public float CalculateEmissionAmount(double greatCircleDistance, double elevationChange)
    {
         return 0.0f;
    } 

    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }
}

