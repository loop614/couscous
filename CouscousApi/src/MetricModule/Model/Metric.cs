using System.ComponentModel.DataAnnotations.Schema;
using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Model;

namespace CouscousApi.MetricModule.Model;

public class Metric : CouscousEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? MetricId {get; set;}

    public int ActivityId { get; set; }

    public Activity? Activity {get; set;} = null!;

    public double? MetricValue {get; set;}

    public string MetricKey {get; set;} = string.Empty;
}
