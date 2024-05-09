using CouscousApi.ActivityModule.Model;
using CouscousApi.ActivityModule.Transfer;
using CouscousApi.Core.Persistence;

namespace CouscousApi.ActivityModule.Persistence;

public class ActivityRepository(CouscousContext couscousContext) : IActivityRepository
{
    public int CountActivities()
    {
        return couscousContext.Activities.Count();
    }

    public ActivityTransfer? GetActivity(int idActivity)
    {
        Activity? activity = couscousContext.Activities
            .SingleOrDefault(activity => activity.ActivityId == idActivity);

        if (activity == null) { return null; }

        return MapActivityToTranfer(activity, new ActivityTransfer());
    }

    private static ActivityTransfer MapActivityToTranfer(Activity activity, ActivityTransfer activityTransfer)
    {
        activityTransfer.ActivityId = activity.ActivityId;
        activityTransfer.ExternalActivityId = activity.ExternalActivityId;
        activityTransfer.ActivityType = activity.ActivityType.ToString();
        activityTransfer.MeasurementCount = activity.MeasurementCount;
        activityTransfer.MetricsCount = activity.MetricsCount;
        activityTransfer.DetailsAvailable = activity.DetailsAvailable;
        activityTransfer.MinLat = activity.MinLat;
        activityTransfer.MinLon = activity.MinLon;
        activityTransfer.MaxLat = activity.MaxLat;
        activityTransfer.MaxLon = activity.MaxLon;

        return activityTransfer;
    }
}
