using System.ComponentModel.DataAnnotations.Schema;
using CouscousApi.Core.Model;
using CouscousApi.EventModule.Model;

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

    public ICollection<Event> Events { get; set; } = [];
}

public enum ActivityTypeEnum
{
    Run = 1,
    Bike = 2,
    Swim = 3
}
