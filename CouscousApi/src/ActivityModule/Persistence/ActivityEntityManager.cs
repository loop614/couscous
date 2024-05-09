using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventElasticModule;

namespace CouscousApi.ActivityModule.Persistence;

public class ActivityEntityManager(CouscousContext couscousContext, IEventElasticService eventElasticService) : IActivityEntityManager
{
    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics)
    {
        Activity activity = MapGarminActivityMetricToActivity(new Activity(), garminActivityMetrics);
        couscousContext.Activities.Add(activity);
        couscousContext.SaveChanges();
        Console.WriteLine($"Created activity {activity.ActivityId}");

        eventElasticService.SaveEvents(activity, garminActivityMetrics);

        return activity;
    }

    private static Activity MapGarminActivityMetricToActivity(Activity activity, GarminActivityMetric garminActivityMetrics)
    {
        activity.ExternalActivityId = garminActivityMetrics.activityId;
        activity.MeasurementCount = garminActivityMetrics.measurementCount;
        activity.MetricsCount = garminActivityMetrics.metricsCount;
        activity.DetailsAvailable = garminActivityMetrics.detailsAvailable;
        activity.MinLat = garminActivityMetrics.geoPolylineDTO.minLat;
        activity.MinLon = garminActivityMetrics.geoPolylineDTO.minLon;
        activity.MaxLat = garminActivityMetrics.geoPolylineDTO.maxLat;
        activity.MaxLon = garminActivityMetrics.geoPolylineDTO.maxLon;
        activity.ActivityType = ActivityTypeEnum.Run;

        return activity;
    }
}
