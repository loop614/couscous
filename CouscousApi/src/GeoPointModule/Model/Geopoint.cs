using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Model;

namespace CouscousApi.GeoPointModule.Model;

public class Geopoint : CouscousEntity
{
    public required string GeopointId { get; set; }

    public Activity? Activity { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public double? Altitude { get; set; }

    public long TimestampPoint { get; set; }

    public bool TimerStart { get; set; }

    public bool TimerStop { get; set; }

    public double? DistanceFromPreviousPoint { get; set; }

    public double? DistanceInMeters { get; set; }

    public double Speed { get; set; }

    public double? CumulativeAscent { get; set; }

    public double? CumulativeDescent { get; set; }

    public bool ExtendedCoordinate { get; set; }

    public bool Valid { get; set; }
}
