using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;
using CouscousApi.ActivityModule.Persistence;
using CouscousApi.ActivityModule.Model;

namespace CouscousApi.ActivityModule;

/// <summary>
/// Entrypoint for Activity Module, which has access to the activity table.
/// </summary>
public interface IActivityService
{
    public GarminActivityMetric GetActivity(int idActivity);

    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics);
}
