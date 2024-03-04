using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule.Model;

namespace CouscousApi.EventModule.Persistence;

public class EventEntityManager : CouscousEntityManager, IEventEntityManager
{
    private CouscousContext _couscousContext;

    public EventEntityManager(CouscousContext couscousContext)
    {
        this._couscousContext = couscousContext;
    }

    public List<Event> SaveEvents(Activity activity, GarminActivityMetric garminActivityMetrics)
    {
        var transaction = this._couscousContext.Database.BeginTransaction();
        Dictionary<string, int> metricKeys = MapMetricKeys(garminActivityMetrics);
        int polylinesPerMetric = (int)garminActivityMetrics.activityDetailMetrics.Count / garminActivityMetrics.geoPolylineDTO.polyline.Count;
        int eventCount = 0;

        for (int i = 0; i < garminActivityMetrics.geoPolylineDTO.polyline.Count; i++)
        {
            for (int j = 0; j < polylinesPerMetric; j++)
            {
                Event eventEntity = new() { ActivityId = activity.ActivityId };
                HydrateEventEntityWithPolyline(eventEntity, garminActivityMetrics.geoPolylineDTO.polyline[i]);
                HydrateEventEntityWithMetrics(eventEntity, garminActivityMetrics.activityDetailMetrics[eventCount].metrics, metricKeys);
                this._couscousContext.Events.Add(eventEntity);
                eventCount++;
                if (eventCount > garminActivityMetrics.activityDetailMetrics.Count) { eventCount = garminActivityMetrics.activityDetailMetrics.Count; }
            }
            if (eventCount > 50) break;
        }

        this._couscousContext.SaveChanges();
        var events = this._couscousContext.Events.ToList();
        transaction.Commit();

        return events;
    }

    private void HydrateEventEntityWithPolyline(Event eventEntity, GarminGeoPoint geoPoint)
    {
        eventEntity.Latitude = geoPoint.lat;
        eventEntity.Longitude = geoPoint.lon;
        eventEntity.Altitude = geoPoint.altitude ?? 0;
        eventEntity.TimestampPoint = geoPoint.time;
        eventEntity.TimerStart = geoPoint.timerStart;
        eventEntity.TimerStop = geoPoint.timerStop;
        eventEntity.DistanceFromPreviousPoint = geoPoint.distanceFromPreviousPoint ?? 0;
        eventEntity.DistanceInMeters = geoPoint.distanceInMeters ?? 0;
        eventEntity.Speed = geoPoint.speed;
        eventEntity.CumulativeAscent = geoPoint.cumulativeAscent ?? 0;
        eventEntity.CumulativeDescent = geoPoint.cumulativeDescent ?? 0;
        eventEntity.ExtendedCoordinate = geoPoint.extendedCoordinate;
        eventEntity.Valid = geoPoint.valid;
    }

    private static Dictionary<string, int> MapMetricKeys(GarminActivityMetric garminActivityMetrics)
    {
        Dictionary<String, int> metricKeys = new();

        for (int i = 0; i < garminActivityMetrics.metricDescriptors.Count; i++)
        {
            metricKeys[garminActivityMetrics.metricDescriptors[i].key] = i;
        }

        return metricKeys;
    }

    private static void HydrateEventEntityWithMetrics(Event eventEntity, List<double?> metrics, Dictionary<String, int> metricKeys)
    {
        eventEntity.DirectRunCadence = metrics[metricKeys["directRunCadence"]];
        eventEntity.DirectFractionalCadence = metrics[metricKeys["directFractionalCadence"]];
        eventEntity.DirectPower = metrics[metricKeys["directPower"]];
        eventEntity.SumMovingDuration = metrics[metricKeys["sumMovingDuration"]];
        eventEntity.DirectElevation = metrics[metricKeys["directElevation"]];
        eventEntity.SumDistance = metrics[metricKeys["sumDistance"]];
        eventEntity.DirectBodyBattery = metrics[metricKeys["directBodyBattery"]];
        eventEntity.DirectSpeed = metrics[metricKeys["directSpeed"]];
        eventEntity.DirectTimestamp = metrics[metricKeys["directTimestamp"]];
        eventEntity.DirectHeartRate = metrics[metricKeys["directHeartRate"]];
        eventEntity.SumDuration = metrics[metricKeys["sumDuration"]];
        eventEntity.DirectVerticalSpeed = metrics[metricKeys["directVerticalSpeed"]];
        eventEntity.DirectCorrectedElevation = metrics[metricKeys["directCorrectedElevation"]];
        eventEntity.DirectUncorrectedElevation = metrics[metricKeys["directUncorrectedElevation"]];
        eventEntity.DirectLatitude = metrics[metricKeys["directLatitude"]];
        eventEntity.DirectLongitude = metrics[metricKeys["directLongitude"]];
        eventEntity.DirectGradeAdjustedSpeed = metrics[metricKeys["directGradeAdjustedSpeed"]];
        eventEntity.SumAccumulatedPower = metrics[metricKeys["sumAccumulatedPower"]];
        eventEntity.DirectGroundContactTime = metrics[metricKeys["directGroundContactTime"]];
        eventEntity.DirectVerticalOscillation = metrics[metricKeys["directVerticalOscillation"]];
        eventEntity.DirectStrideLength = metrics[metricKeys["directStrideLength"]];
        eventEntity.DirectVerticalRatio = metrics[metricKeys["directVerticalRatio"]];
        eventEntity.DirectPerformanceCondition = metrics[metricKeys["directPerformanceCondition"]];
    }
}
