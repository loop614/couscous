using CouscousApi.ActivityModule.Model;
using CouscousApi.ActivityModule.Transfer;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule.Model;
using Microsoft.EntityFrameworkCore;

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
            .Include(activity => activity.Events)
            .AsSplitQuery()
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

        foreach(Event eventEntity in activity.Events) {
            activityTransfer.Events.Add(
                MapEventToTransfer(eventEntity, new EventTransfer())
            );
        }

        return activityTransfer;
    }

    private static EventTransfer MapEventToTransfer(Event eventEntity, EventTransfer eventTransfer)
    {
        eventTransfer.DirectRunCadence = eventEntity.DirectRunCadence;
        eventTransfer.DirectFractionalCadence = eventEntity.DirectFractionalCadence;
        eventTransfer.DirectPower = eventEntity.DirectPower;
        eventTransfer.SumMovingDuration = eventEntity.SumMovingDuration;
        eventTransfer.DirectElevation = eventEntity.DirectElevation;
        eventTransfer.SumDistance = eventEntity.SumDistance;
        eventTransfer.DirectBodyBattery = eventEntity.DirectBodyBattery;
        eventTransfer.DirectSpeed = eventEntity.DirectSpeed;
        eventTransfer.DirectTimestamp = eventEntity.DirectTimestamp;
        eventTransfer.DirectHeartRate = eventEntity.DirectHeartRate;
        eventTransfer.SumDuration = eventEntity.SumDuration;
        eventTransfer.DirectVerticalSpeed = eventEntity.DirectVerticalSpeed;
        eventTransfer.DirectCorrectedElevation = eventEntity.DirectCorrectedElevation;
        eventTransfer.DirectUncorrectedElevation = eventEntity.DirectUncorrectedElevation;
        eventTransfer.DirectLatitude = eventEntity.DirectLatitude;
        eventTransfer.DirectLongitude = eventEntity.DirectLongitude;
        eventTransfer.DirectGradeAdjustedSpeed = eventEntity.DirectGradeAdjustedSpeed;
        eventTransfer.SumAccumulatedPower = eventEntity.SumAccumulatedPower;
        eventTransfer.DirectGroundContactTime = eventEntity.DirectGroundContactTime;
        eventTransfer.DirectVerticalOscillation = eventEntity.DirectVerticalOscillation;
        eventTransfer.DirectStrideLength = eventEntity.DirectStrideLength;
        eventTransfer.DirectVerticalRatio = eventEntity.DirectVerticalRatio;
        eventTransfer.DirectPerformanceCondition = eventEntity.DirectPerformanceCondition;
        eventTransfer.Latitude = eventEntity.Latitude;
        eventTransfer.Longitude = eventEntity.Longitude;
        eventTransfer.Altitude = eventEntity.Altitude;
        eventTransfer.TimestampPoint = eventEntity.TimestampPoint;
        eventTransfer.TimerStart = eventEntity.TimerStart;
        eventTransfer.TimerStop = eventEntity.TimerStop;
        eventTransfer.DistanceFromPreviousPoint = eventEntity.DistanceFromPreviousPoint;
        eventTransfer.DistanceInMeters = eventEntity.DistanceInMeters;
        eventTransfer.Speed = eventEntity.Speed;
        eventTransfer.CumulativeAscent = eventEntity.CumulativeAscent;
        eventTransfer.CumulativeDescent = eventEntity.CumulativeDescent;
        eventTransfer.ExtendedCoordinate = eventEntity.ExtendedCoordinate;
        eventTransfer.Valid = eventEntity.Valid;

        return eventTransfer;
    }
}
