using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Persistence;
using CouscousApi.GeoPointModule.Model;
using CouscousApi.MetricModule.Model;
using Microsoft.EntityFrameworkCore;

namespace CouscousApi.ActivityModule.Persistence;

public class ActivityRepository : CouscousRepository, IActivityRepository
{
    private CouscousContext _couscousContext;

    public ActivityRepository(CouscousContext couscousContext)
    {
        this._couscousContext = couscousContext;
    }

    public int CountActivities()
    {
        return this._couscousContext.Activities.Count();
    }

    public ActivityTransfer? GetActivity(int idActivity)
    {
        Activity? activity = this._couscousContext.Activities
            .Include(activity => activity.Metrics)
            .AsSplitQuery()
            .Include(activity => activity.GeoPoints)
            .AsSplitQuery()
            .SingleOrDefault(activity => activity.ActivityId == idActivity);

        return this.MapActivityToTranfer(activity, new ActivityTransfer());
    }

    private ActivityTransfer? MapActivityToTranfer(Activity? activity, ActivityTransfer activityTransfer)
    {
        if (activity == null) { return activityTransfer; }
        activityTransfer.ActivityId = activity.ActivityId;
        activityTransfer.ExternalActivityId = activity.ExternalActivityId;
        activityTransfer.ActivityType = activity.ActivityType.ToString();
        activityTransfer.MeasurementCount = activity.MeasurementCount;
        activityTransfer.MetricsCount = activity.MetricsCount;
        activityTransfer.DetailsAvailable = activity.DetailsAvailable;

        foreach (var metric in activity.Metrics)
        {
            activityTransfer.Metrics.Add(this.MapMetricToTransfer(metric, new MetricTransfer()));
        }

        foreach (var geoPoint in activity.GeoPoints)
        {
            activityTransfer.GeoPoints.Add(this.MapGeoPointToTransfer(geoPoint, new GeopointTranfer()));
        }

        return activityTransfer;
    }

    private GeopointTranfer MapGeoPointToTransfer(Geopoint geoPoint, GeopointTranfer geopointTranfer)
    {
        geopointTranfer.GeopointId = geoPoint.GeopointId;
        geopointTranfer.Latitude = geoPoint.Latitude;
        geopointTranfer.Longitude = geoPoint.Longitude;
        geopointTranfer.Altitude = geoPoint.Altitude;
        geopointTranfer.TimestampPoint = geoPoint.TimestampPoint;
        geopointTranfer.TimerStart = geoPoint.TimerStart;
        geopointTranfer.TimerStop = geoPoint.TimerStop;
        geopointTranfer.DistanceFromPreviousPoint = geoPoint.DistanceFromPreviousPoint;
        geopointTranfer.DistanceInMeters = geoPoint.DistanceInMeters;
        geopointTranfer.Speed = geoPoint.Speed;
        geopointTranfer.CumulativeAscent = geoPoint.CumulativeAscent;
        geopointTranfer.CumulativeDescent = geoPoint.CumulativeDescent;
        geopointTranfer.ExtendedCoordinate = geoPoint.ExtendedCoordinate;
        geopointTranfer.Valid = geoPoint.Valid;

        return geopointTranfer;
    }

    private MetricTransfer MapMetricToTransfer(Metric metric, MetricTransfer metricTransfer)
    {
        metricTransfer.MetricId = metric.MetricId;
        metricTransfer.MetricKey = metric.MetricKey;
        metricTransfer.MetricValue = metric.MetricValue;

        return metricTransfer;
    }
}
