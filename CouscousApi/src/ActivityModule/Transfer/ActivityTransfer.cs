using CouscousApi.GeoPointModule.Model;
using CouscousApi.MetricModule.Model;

namespace CouscousApi.ActivityModule.Model;

public class ActivityTransfer
{
    public int ActivityId { get; set; }

    public long ExternalActivityId { get; set; }

    public String ActivityType { get; set; } = null!;

    public int MeasurementCount { get; set; }

    public int MetricsCount { get; set; }

    public bool DetailsAvailable { get; set; }

    public ICollection<MetricTransfer> Metrics { get; set; } = [];

    public ICollection<GeopointTranfer> GeoPoints { get; set; } = [];
}
