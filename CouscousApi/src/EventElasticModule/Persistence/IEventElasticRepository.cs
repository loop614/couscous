using CouscousApi.DataImport.Transfer;
using CouscousApi.EventElasticModule.Model;

namespace CouscousApi.EventElasticModule.Persistence;

public interface IEventElasticRepository
{
    public Task<List<EventElastic>> GetEvents(int activityId);
}
