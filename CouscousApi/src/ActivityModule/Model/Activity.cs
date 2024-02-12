using CouscousApi.Core.Model;
using CouscousApi.GeoPointModule.Model;
using CouscousApi.MetricModule.Model;

namespace CouscousApi.ActivityModule.Model;

public class Activity : CouscousEntity
{
    public required string ActivityId { get; set; }

    public long ExternalActivityId { get; set; }

    public ActivityTypeEnum ActivityType { get; set; }

    public int MeasurementCount { get; set; }

    public int MetricsCount { get; set; }

    public bool DetailsAvailable { get; set; }

    public List<Metric> Metrics { get; set; } = [];

    public List<Geopoint> GeoPoints { get; set; } = [];
}

public enum ActivityTypeEnum
{
    Run = 1,
    Bike = 2,
    Swim = 3
}
