using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule;

namespace CouscousApi.ActivityModule.Persistence;

public class ActivityEntityManager(CouscousContext couscousContext, IEventService eventService) : CouscousEntityManager, IActivityEntityManager
{
    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics)
    {
        Activity activity = MapGarminActivityMetricToActivity(new Activity(), garminActivityMetrics);
        couscousContext.Activities.Add(activity);
        couscousContext.SaveChanges();

        eventService.SaveEvents(activity, garminActivityMetrics);

        return activity;
    }

    private static Activity MapGarminActivityMetricToActivity(Activity activity, GarminActivityMetric garminActivityMetrics)
    {
        activity.ExternalActivityId = garminActivityMetrics.activityId;
        activity.MeasurementCount = garminActivityMetrics.measurementCount;
        activity.MetricsCount = garminActivityMetrics.metricsCount;
        activity.DetailsAvailable = garminActivityMetrics.detailsAvailable;
        activity.ActivityType = ActivityTypeEnum.Run;

        return activity;
    }
}
