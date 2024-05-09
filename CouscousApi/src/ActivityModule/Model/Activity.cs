using System.ComponentModel.DataAnnotations.Schema;

namespace CouscousApi.ActivityModule.Model;

public class Activity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ActivityId { get; set; }

    public long ExternalActivityId { get; set; }

    public ActivityTypeEnum ActivityType { get; set; }

    public int MeasurementCount { get; set; }

    public int MetricsCount { get; set; }

    public bool DetailsAvailable { get; set; }

    public double MinLat { get; set; }

    public double MaxLat { get; set; }

    public double MinLon { get; set; }

    public double MaxLon { get; set; }
}

public enum ActivityTypeEnum
{
    Run = 1,
    Bike = 2,
    Swim = 3
}
