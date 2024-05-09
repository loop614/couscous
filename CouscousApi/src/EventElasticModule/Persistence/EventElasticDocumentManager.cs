using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventElasticModule.Model;
using Elastic.Clients.Elasticsearch;

namespace CouscousApi.EventElasticModule.Persistence;

public class EventElasticDocumentManager(CouscousElasticClient couscousElasticClient) : IEventElasticDocumentManager
{
    public async void SaveEvents(Activity activity, GarminActivityMetric garminActivityMetrics)
    {
        Dictionary<string, int> metricKeys = MapMetricKeys(garminActivityMetrics);
        int polylinesPerMetric = (int)garminActivityMetrics.activityDetailMetrics.Count / garminActivityMetrics.geoPolylineDTO.polyline.Count;
        int eventCount = 0;
        List<EventElastic> events = [];

        for (int i = 0; i < garminActivityMetrics.geoPolylineDTO.polyline.Count; i++)
        {
            eventCount = i * polylinesPerMetric;
            for (int j = 0; j < polylinesPerMetric; j++)
            {
                EventElastic eventDocument = new() { ActivityId = activity.ActivityId };
                HydrateEventEntityWithPolyline(eventDocument, garminActivityMetrics.geoPolylineDTO.polyline[i]);
                HydrateEventEntityWithMetrics(eventDocument, garminActivityMetrics.activityDetailMetrics[eventCount].metrics, metricKeys);
                events.Add(eventDocument);
                eventCount++;
            }
            if (events.Count > 200) {
                Console.WriteLine("adding " + events.Count + " events to elastic");
                await couscousElasticClient.client!.IndexManyAsync<EventElastic>(events, "couscous_events");
                events.Clear();
            }
        }
        if (events.Count > 0) {
            Console.WriteLine("adding " + events.Count + " events to elastic");
            await couscousElasticClient.client!.IndexManyAsync<EventElastic>(events, "couscous_events");
        }
    }

    private static void HydrateEventEntityWithPolyline(EventElastic eventDocument, GarminGeoPoint geoPoint)
    {
        eventDocument.Latitude = geoPoint.lat;
        eventDocument.Longitude = geoPoint.lon;
        eventDocument.Altitude = geoPoint.altitude ?? 0;
        eventDocument.TimestampPoint = geoPoint.time;
        eventDocument.TimerStart = geoPoint.timerStart;
        eventDocument.TimerStop = geoPoint.timerStop;
        eventDocument.DistanceFromPreviousPoint = geoPoint.distanceFromPreviousPoint ?? 0;
        eventDocument.DistanceInMeters = geoPoint.distanceInMeters ?? 0;
        eventDocument.Speed = geoPoint.speed;
        eventDocument.CumulativeAscent = geoPoint.cumulativeAscent ?? 0;
        eventDocument.CumulativeDescent = geoPoint.cumulativeDescent ?? 0;
        eventDocument.ExtendedCoordinate = geoPoint.extendedCoordinate;
        eventDocument.Valid = geoPoint.valid;
    }

    private static Dictionary<string, int> MapMetricKeys(GarminActivityMetric garminActivityMetrics)
    {
        Dictionary<string, int> metricKeys = new();

        for (int i = 0; i < garminActivityMetrics.metricDescriptors.Count; i++)
        {
            metricKeys[garminActivityMetrics.metricDescriptors[i].key] = i;
        }

        return metricKeys;
    }

    private static void HydrateEventEntityWithMetrics(EventElastic eventDocument, List<double?> metrics, Dictionary<string, int> metricKeys)
    {
        eventDocument.DirectRunCadence = metrics[metricKeys["directRunCadence"]];
        eventDocument.DirectFractionalCadence = metrics[metricKeys["directFractionalCadence"]];
        eventDocument.DirectPower = metrics[metricKeys["directPower"]];
        eventDocument.SumMovingDuration = metrics[metricKeys["sumMovingDuration"]];
        eventDocument.DirectElevation = metrics[metricKeys["directElevation"]];
        eventDocument.SumDistance = metrics[metricKeys["sumDistance"]];
        eventDocument.DirectBodyBattery = metrics[metricKeys["directBodyBattery"]];
        eventDocument.DirectSpeed = metrics[metricKeys["directSpeed"]];
        eventDocument.DirectTimestamp = metrics[metricKeys["directTimestamp"]];
        eventDocument.DirectHeartRate = metrics[metricKeys["directHeartRate"]];
        eventDocument.SumDuration = metrics[metricKeys["sumDuration"]];
        eventDocument.DirectVerticalSpeed = metrics[metricKeys["directVerticalSpeed"]];
        eventDocument.DirectCorrectedElevation = metrics[metricKeys["directCorrectedElevation"]];
        eventDocument.DirectUncorrectedElevation = metrics[metricKeys["directUncorrectedElevation"]];
        eventDocument.DirectLatitude = metrics[metricKeys["directLatitude"]];
        eventDocument.DirectLongitude = metrics[metricKeys["directLongitude"]];
        eventDocument.DirectGradeAdjustedSpeed = metrics[metricKeys["directGradeAdjustedSpeed"]];
        eventDocument.SumAccumulatedPower = metrics[metricKeys["sumAccumulatedPower"]];
        eventDocument.DirectGroundContactTime = metrics[metricKeys["directGroundContactTime"]];
        eventDocument.DirectVerticalOscillation = metrics[metricKeys["directVerticalOscillation"]];
        eventDocument.DirectStrideLength = metrics[metricKeys["directStrideLength"]];
        eventDocument.DirectVerticalRatio = metrics[metricKeys["directVerticalRatio"]];
        eventDocument.DirectPerformanceCondition = metrics[metricKeys["directPerformanceCondition"]];
    }
}
