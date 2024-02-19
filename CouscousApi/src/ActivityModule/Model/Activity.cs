using System.ComponentModel.DataAnnotations.Schema;
using CouscousApi.Core.Model;
using CouscousApi.GeoPointModule.Model;
using CouscousApi.MetricModule.Model;

namespace CouscousApi.ActivityModule.Model;

public class Activity : CouscousEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ActivityId { get; set; }

    public long ExternalActivityId { get; set; }

    public ActivityTypeEnum ActivityType { get; set; }

    public int MeasurementCount { get; set; }

    public int MetricsCount { get; set; }

    public bool DetailsAvailable { get; set; }

    public ICollection<Metric> Metrics { get; set; } = [];

    public ICollection<Geopoint> GeoPoints { get; set; } = [];
}

public enum ActivityTypeEnum
{
    Run = 1,
    Bike = 2,
    Swim = 3
}
