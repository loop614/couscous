namespace CouscousApi.MetricModule.Model;

public class MetricTransfer
{
    public int? MetricId {get; set;}

    public double? MetricValue {get; set;}

    public string MetricKey {get; set;} = string.Empty;
}
