using CouscousApi.ActivityModule.Transfer;

namespace CouscousApi.DataImport.Transfer;

public class EventTransfer
{
    public int EventId { get; set; }

    public int ActivityId { get; set; } = 0;

    public double? DirectRunCadence { get; set; }

    public double? SumElapsedDuration { get; set; }

    public double? DirectFractionalCadence { get; set; }

    public double? DirectPower { get; set; }

    public double? SumMovingDuration { get; set; }

    public double? DirectElevation { get; set; }

    public double? SumDistance { get; set; }

    public double? DirectBodyBattery { get; set; }

    public double? DirectSpeed { get; set; }

    public double? DirectTimestamp { get; set; }

    public double? DirectHeartRate { get; set; }

    public double? SumDuration { get; set; }

    public double? DirectVerticalSpeed { get; set; }

    public double? DirectCorrectedElevation { get; set; }

    public double? DirectUncorrectedElevation { get; set; }

    public double? DirectLatitude { get; set; }

    public double? DirectLongitude { get; set; }

    public double? DirectGradeAdjustedSpeed { get; set; }

    public double? SumAccumulatedPower { get; set; }

    public double? DirectGroundContactTime { get; set; }

    public double? DirectVerticalOscillation { get; set; }

    public double? DirectStrideLength { get; set; }

    public double? DirectVerticalRatio { get; set; }

    public double? DirectPerformanceCondition { get; set; }

    public double Latitude { get; set; } = 0;

    public double Longitude { get; set; } = 0;

    public double Altitude { get; set; } = 0;

    public long TimestampPoint { get; set; } = 0;

    public bool TimerStart { get; set; } = false;

    public bool TimerStop { get; set; } = false;

    public double? DistanceFromPreviousPoint { get; set; }

    public double? DistanceInMeters { get; set; }

    public double Speed { get; set; } = 0;

    public double? CumulativeAscent { get; set; }

    public double? CumulativeDescent { get; set; }

    public bool ExtendedCoordinate { get; set; } = false;

    public bool Valid { get; set; } = false;
}
