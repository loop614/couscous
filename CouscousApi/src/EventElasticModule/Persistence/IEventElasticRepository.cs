using CouscousApi.DataImport.Transfer;

namespace CouscousApi.EventElasticModule.Persistence;

public interface IEventElasticRepository
{
    List<EventTransfer> GetEvents(int activityId);
}
