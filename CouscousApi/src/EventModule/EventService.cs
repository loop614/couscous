using CouscousApi.ActivityModule.Model;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule.Model;
using CouscousApi.EventModule.Persistence;

namespace CouscousApi.EventModule;

public class EventService(IEventEntityManager eventEntityManager, IEventRepository eventRepository) : IEventService
{
    public int CountEvents()
    {
        return eventRepository.CountEvents();
    }

    public List<EventTransfer> GetEvents(int idEvent)
    {
        return eventRepository.GetEvents(idEvent);
    }

    public List<Event> SaveEvents(Activity activity, GarminActivityMetric garminEventMetrics)
    {
        return eventEntityManager.SaveEvents(activity, garminEventMetrics);
    }
}
