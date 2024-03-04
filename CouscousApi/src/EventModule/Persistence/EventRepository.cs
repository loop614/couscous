using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule.Model;

namespace CouscousApi.EventModule.Persistence;

public class EventRepository(CouscousContext couscousContext) : CouscousRepository, IEventRepository
{
    public int CountEvents()
    {
        return couscousContext.Activities.Count();
    }

    public List<EventTransfer> GetEvents(int idActivity)
    {
        List<Event> events = couscousContext.Events
            .Where(s => s.ActivityId == idActivity)
            .ToList();

        return MapEventsToTransfer(events, new List<EventTransfer>());
    }

    private static List<EventTransfer> MapEventsToTransfer(List<Event> events, List<EventTransfer> eventsResponseTransfer)
    {
        if (events.Count == 0) { return eventsResponseTransfer; }
        foreach (Event eventEntity in events)
        {
            EventTransfer eventTransfer = new()
            {
                EventId = eventEntity.EventId,
                ActivityId = eventEntity.ActivityId,
                DirectRunCadence = eventEntity.DirectRunCadence,
                SumElapsedDuration = eventEntity.SumElapsedDuration,
                DirectFractionalCadence = eventEntity.DirectFractionalCadence,
                DirectPower = eventEntity.DirectPower,
                SumMovingDuration = eventEntity.SumMovingDuration,
                DirectElevation = eventEntity.DirectElevation,
                SumDistance = eventEntity.SumDistance,
                DirectBodyBattery = eventEntity.DirectBodyBattery,
                DirectSpeed = eventEntity.DirectSpeed,
                DirectTimestamp = eventEntity.DirectTimestamp,
                DirectHeartRate = eventEntity.DirectHeartRate,
                SumDuration = eventEntity.SumDuration,
                DirectVerticalSpeed = eventEntity.DirectVerticalSpeed,
                DirectCorrectedElevation = eventEntity.DirectCorrectedElevation,
                DirectUncorrectedElevation = eventEntity.DirectUncorrectedElevation,
                DirectLatitude = eventEntity.DirectLatitude,
                DirectLongitude = eventEntity.DirectLongitude,
                DirectGradeAdjustedSpeed = eventEntity.DirectGradeAdjustedSpeed,
                SumAccumulatedPower = eventEntity.SumAccumulatedPower,
                DirectGroundContactTime = eventEntity.DirectGroundContactTime,
                DirectVerticalOscillation = eventEntity.DirectVerticalOscillation,
                DirectStrideLength = eventEntity.DirectStrideLength,
                DirectVerticalRatio = eventEntity.DirectVerticalRatio,
                DirectPerformanceCondition = eventEntity.DirectPerformanceCondition,
                Latitude = eventEntity.Latitude,
                Longitude = eventEntity.Longitude,
                Altitude = eventEntity.Altitude,
                TimestampPoint = eventEntity.TimestampPoint,
                TimerStart = eventEntity.TimerStart,
                TimerStop = eventEntity.TimerStop,
                DistanceFromPreviousPoint = eventEntity.DistanceFromPreviousPoint,
                DistanceInMeters = eventEntity.DistanceInMeters,
                Speed = eventEntity.Speed,
                CumulativeAscent = eventEntity.CumulativeAscent,
                CumulativeDescent = eventEntity.CumulativeDescent,
                ExtendedCoordinate = eventEntity.ExtendedCoordinate,
                Valid = eventEntity.Valid
            };
            eventsResponseTransfer.Add(eventTransfer);
        }

        return eventsResponseTransfer;
    }
}
