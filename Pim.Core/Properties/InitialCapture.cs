using System.Globalization;

namespace Pim.Core.Properties;

public class Capture
{
    private DateTime CaptureDate { get; set; }
    private float Height { get; set; }
    private float Longitude { get; set; }
    private float Latitude { get; set; }
    private float RightAscension { get; set; }
    private float Declination { get; set; }
    
    public double CaptureDateToJulianDate() => CaptureDate.ToOADate() + 2415018.5;

    public DateTime GetDateFromJulian(string julianDate)
    {
        int year = Convert.ToInt32(julianDate.Substring(2, 2));
        int day = Convert.ToInt32(julianDate.Substring(4));
        DateTime dt = new DateTime(1999 + year, 12, 18, new JulianCalendar());
 
        dt = dt.AddDays(day);
 
        return dt;
    }

    public double GetAzimuth(double HoraryAngle, double rightAscencion, double declination, double lat)
    {
        var v1 = Math.Sin(HoraryAngle);
        var v2 = (v1 / ((Math.Cos(HoraryAngle) * Math.Sin(lat)) - (Math.Tan(declination) * Math.Cos(lat))));
        var azimuth = Math.Atan(v2);
        return azimuth;
    }
    
    public double GetHorizonAltitudeFromEquatorial(double HoraryAngle, double rightAscencion, double declination, double lat)
    {
        var v1 = (Math.Sin(lat) * Math.Sin(declination)) + (Math.Cos(lat) * Math.Cos(HoraryAngle));
        var altu = Math.Asin(v1);
        return altu;
    }
}