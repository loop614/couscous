using CouscousApi.ActivityModule.Model;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventElasticModule.Model;

namespace CouscousApi.EventElasticModule;

public interface IEventElasticService
{
    void SaveEvents(Activity activity, GarminActivityMetric garminActivityMetrics);

    public Task<List<EventElastic>> GetEvents(int activityId);
}
