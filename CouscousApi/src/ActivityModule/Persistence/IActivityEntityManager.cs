using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;

namespace CouscousApi.ActivityModule.Persistence;

public interface IActivityEntityManager
{
    public Activity SaveActivity(GarminActivityMetric garminActivityMetrics);
}
