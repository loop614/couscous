namespace CouscousApi.DataImport.Transfer;

public class GarminActivityMetric
{
    public long activityId { get; set; }

    public int measurementCount { get; set; }

    public int metricsCount { get; set; }

    public List<MetricDescriptor> metricDescriptors { get; set; } = [];

    public List<ActivityDetailMetric> activityDetailMetrics { get; set; } = [];

    public GeoPolyline geoPolylineDTO { get; set; } = new();

    public object? heartRateDTOs { get; set; }

    public bool detailsAvailable { get; set; }
}

public class MetricDescriptor
{
    public int metricsIndex { get; set; }
    public string? key { get; set; }
    public Unit unit { get; set; } = new();
}

public class ActivityDetailMetric
{
    public List<double?> metrics { get; set; } = [];
}


public class GeoPolyline
{
    public GeoPoint startPoint { get; set; } = new();
    public GeoPoint endPoint { get; set; } = new();
    public double minLat { get; set; }
    public double maxLat { get; set; }
    public double minLon { get; set; }
    public double maxLon { get; set; }
    public List<GeoPoint> polyline { get; set; } = [];
}

public class GeoPoint
{
    public double lat { get; set; }
    public double lon { get; set; }
    public double? altitude { get; set; }
    public long time { get; set; }
    public bool timerStart { get; set; }
    public bool timerStop { get; set; }
    public double? distanceFromPreviousPoint { get; set; }
    public double? distanceInMeters { get; set; }
    public double speed { get; set; }
    public double? cumulativeAscent { get; set; }
    public double? cumulativeDescent { get; set; }
    public bool extendedCoordinate { get; set; }
    public bool valid { get; set; }
}

public class Unit
{
    public int id { get; set; }
    public string? key { get; set; }
    public double factor { get; set; }
}
