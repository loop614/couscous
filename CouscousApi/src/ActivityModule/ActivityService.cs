using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;

namespace CouscousApi.ActivityModule;

/// <summary>
/// Entrypoint for Activity Module, which has access to the activity table.
/// </summary>
public class ActivityService : CouscousService, IActivityService
{
    public GarminActivityMetric GetActivity(int idActivity)
    {
        return new GarminActivityMetric();
    }

    public GarminActivityMetric SaveActivity(GarminActivityMetric garminActivityMetrics)
    {
        return new GarminActivityMetric();
    }
}
