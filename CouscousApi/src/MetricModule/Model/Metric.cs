using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Model;

namespace CouscousApi.MetricModule.Model;

public class Metric : CouscousEntity
{
    public required string MetricId {get; set;}

    public Activity? Activity {get; set;}

    public double MetricValue {get; set;}

    public string MetricKey {get; set;} = string.Empty;
}
