using CouscousApi.ActivityModule.Model;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventElasticModule.Model;
using CouscousApi.EventElasticModule.Persistence;

namespace CouscousApi.EventElasticModule;

public class EventElasticService(
    IEventElasticDocumentManager eventElasticDocumentManager,
    IEventElasticRepository eventElasticRepository
) : IEventElasticService
{
    public void SaveEvents(Activity activity, GarminActivityMetric garminActivityMetrics)
    {
        eventElasticDocumentManager.SaveEvents(activity, garminActivityMetrics);
    }

    public async Task<List<EventElastic>> GetEvents(int activityId)
    {
        return await eventElasticRepository.GetEvents(activityId);
    }
}
