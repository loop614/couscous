using CouscousApi.DataImport.Transfer;

namespace CouscousApi.EventModule.Persistence;

public interface IEventRepository
{
    public int CountEvents();

    public List<EventTransfer> GetEvents(int idActivity);
}
