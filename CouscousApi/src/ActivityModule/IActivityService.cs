using CouscousApi.DataImport.Transfer;
using CouscousApi.ActivityModule.Model;
using CouscousApi.ActivityModule.Transfer;

namespace CouscousApi.ActivityModule;

/// <summary>
/// Entrypoint for Activity Module, which has access to the activity table.
/// </summary>
public interface IActivityService
{
    public int CountActivities();

    public ActivityTransfer? GetActivity(int idActivity);

    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics);
}
