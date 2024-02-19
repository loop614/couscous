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

    private readonly IActivityRepository _activityRepository;

    public ActivityService(
        IActivityEntityManager activityEntityMangager,
        IActivityRepository activityRepository
    ) {
        this._activityEntityManager = activityEntityMangager;
        this._activityRepository = activityRepository;
    }

    public int CountActivities()
    {
        return this._activityRepository.CountActivities();
    }

    public ActivityTransfer? GetActivity(int idActivity)
    {
        return this._activityRepository.GetActivity(idActivity);
    }

    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics)
    {
        return this._activityEntityManager.SaveActivity(garminActivityMetrics);
    }
}
