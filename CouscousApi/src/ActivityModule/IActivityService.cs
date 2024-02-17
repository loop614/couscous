using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;

namespace CouscousApi.ActivityModule;

/// <summary>
/// Entrypoint for Activity Module, which has access to the activity table.
/// </summary>
public interface IActivityService
{
    public GarminActivityMetric GetActivity(int idActivity);

    public GarminActivityMetric SaveActivity(GarminActivityMetric garminActivityMetrics);
}
