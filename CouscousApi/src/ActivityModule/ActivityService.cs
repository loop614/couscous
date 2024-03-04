using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;
using CouscousApi.ActivityModule.Persistence;
using CouscousApi.ActivityModule.Model;
using CouscousApi.ActivityModule.Transfer;

namespace CouscousApi.ActivityModule;

/// <summary>
/// Entrypoint for Activity Module, which has access to the activity table.
/// </summary>
public class ActivityService(
    IActivityEntityManager activityEntityManager,
    IActivityRepository activityRepository
    ) : CouscousService, IActivityService
{
    public int CountActivities()
    {
        return activityRepository.CountActivities();
    }

    public ActivityTransfer? GetActivity(int idActivity)
    {
        return activityRepository.GetActivity(idActivity);
    }

    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics)
    {
        return activityEntityManager.SaveActivity(garminActivityMetrics);
    }
}
