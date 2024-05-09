using CouscousApi.DataImport.Transfer;

namespace CouscousApi.EventElasticModule.Persistence;

public class EventElasticRepository : IEventElasticRepository
{
    List<EventTransfer> IEventElasticRepository.GetEvents(int activityId)
    {
        throw new NotImplementedException();
    }
}
