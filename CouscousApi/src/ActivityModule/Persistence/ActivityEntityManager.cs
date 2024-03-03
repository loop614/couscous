using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;
using CouscousApi.GeoPointModule.Model;
using CouscousApi.MetricModule.Model;

namespace CouscousApi.ActivityModule.Persistence;

public class ActivityEntityManager : CouscousEntityManager, IActivityEntityManager
{
    private CouscousContext _couscousContext;

    public ActivityEntityManager(CouscousContext couscousContext)
    {
        this._couscousContext = couscousContext;
    }

    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics)
    {
        var transaction = this._couscousContext.Database.BeginTransaction();
        Activity activity = MapGarminActivityMetricToActivity(new Activity(), garminActivityMetrics);
        this._couscousContext.Activities.Add(activity);
        this._couscousContext.SaveChanges();
        AddMetrics(activity, garminActivityMetrics);
        AddGeopoints(activity, garminActivityMetrics);
        this._couscousContext.Activities.Update(activity);
        this._couscousContext.SaveChanges();
        transaction.Commit();

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

    private static void AddGeopoints(Activity activity, GarminActivityMetric garminActivityMetrics)
    {
        int count = 0;
        foreach (GarminGeoPoint gp in garminActivityMetrics.geoPolylineDTO.polyline)
        {
            if (count++ > 50) {break;}
            Geopoint geoPoint = new()
            {
                Activity = activity,
                Latitude = gp.lat,
                Longitude = gp.lon,
                Altitude = gp.altitude,
                TimestampPoint = gp.time,
                TimerStart = gp.timerStart,
                TimerStop = gp.timerStop,
                DistanceFromPreviousPoint = gp.distanceFromPreviousPoint,
                DistanceInMeters = gp.distanceInMeters,
                Speed = gp.speed,
                CumulativeAscent = gp.cumulativeAscent,
                CumulativeDescent = gp.cumulativeDescent,
                ExtendedCoordinate = gp.extendedCoordinate,
                Valid = gp.valid
            };
            activity.GeoPoints.Add(geoPoint);
        }
    }

    private static void AddMetrics(Activity activity, GarminActivityMetric garminActivityMetrics)
    {
        List<String> metricKeys = [];
        foreach (MetricDescriptor md in garminActivityMetrics.metricDescriptors)
        {
            if (md.key != String.Empty)
            {
                metricKeys.Add(md.key);
            }
        }

        int count = 0;
        foreach (ActivityDetailMetric md in garminActivityMetrics.activityDetailMetrics)
        {
            if (count++ > (50 / md.metrics.Count)) {break;}
            for (int i = 0; i < md.metrics.Count; i++)
            {
                Metric metric = new()
                {
                    Activity = activity,
                    MetricKey = metricKeys[i],
                    MetricValue = md.metrics[i]
                };
                activity.Metrics.Add(metric);
            }
        }
    }
}
