using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;
using CouscousApi.ActivityModule.Persistence;
using CouscousApi.ActivityModule.Model;

namespace CouscousApi.ActivityModule;

/// <summary>
/// Entrypoint for Activity Module, which has access to the activity table.
/// </summary>
public class ActivityService : CouscousService, IActivityService
{
    private readonly IActivityEntityManager _activityEntityManager;

    public ActivityService(IActivityEntityManager activityEntityMangager)
    {
        this._activityEntityManager = activityEntityMangager;
    }

    public GarminActivityMetric GetActivity(int idActivity)
    {
        return new GarminActivityMetric();
    }

    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics)
    {
        return this._activityEntityManager.SaveActivity(garminActivityMetrics);
    }
}
