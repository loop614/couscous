using CouscousApi.ActivityModule.Model;
using CouscousApi.DataImport.Transfer;

namespace CouscousApi.EventElasticModule;

public interface IEventElasticService
{
    void SaveEvents(Activity activity, GarminActivityMetric garminActivityMetrics);

    public List<EventTransfer> GetEvents(int activityId);
}
