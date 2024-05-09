namespace CouscousApi.ActivityModule.Transfer;

public class ActivityTransfer
{
    public int ActivityId { get; set; }

    public long ExternalActivityId { get; set; }

    public string ActivityType { get; set; } = string.Empty;

    public int MeasurementCount { get; set; }

    public int MetricsCount { get; set; }

    public bool DetailsAvailable { get; set; }

    public double MinLat { get; set; }

    public double MaxLat { get; set; }

    public double MinLon { get; set; }

    public double MaxLon { get; set; }
}
