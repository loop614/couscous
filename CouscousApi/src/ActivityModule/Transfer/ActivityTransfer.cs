using CouscousApi.DataImport.Transfer;

namespace CouscousApi.ActivityModule.Transfer;

public class ActivityTransfer
{
    public int ActivityId { get; set; }

    public long ExternalActivityId { get; set; }

    public String ActivityType { get; set; } = null!;

    public int MeasurementCount { get; set; }

    public int MetricsCount { get; set; }

    public bool DetailsAvailable { get; set; }

    public ICollection<EventTransfer> Events { get; set; } = [];
}
