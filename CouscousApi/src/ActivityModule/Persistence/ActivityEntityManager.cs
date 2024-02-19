using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;

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
        Activity activity = this.MapGarminActivityMetricToActivity(new Activity(), garminActivityMetrics);
        this._couscousContext.Activities.Add(activity);
        this._couscousContext.SaveChanges();

        return activity;
    }

    private Activity MapGarminActivityMetricToActivity(Activity activity, GarminActivityMetric garminActivityMetrics)
    {
        activity.ExternalActivityId = garminActivityMetrics.activityId;
        activity.MeasurementCount = garminActivityMetrics.measurementCount;
        activity.MetricsCount = garminActivityMetrics.metricsCount;
        activity.DetailsAvailable = garminActivityMetrics.detailsAvailable;

        return activity;
    }
}
