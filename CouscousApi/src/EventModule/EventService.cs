using CouscousApi.ActivityModule.Model;
using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule.Model;
using CouscousApi.EventModule.Persistence;

namespace CouscousApi.EventModule;

/// <summary>
/// Entrypoint for Event Module, which has access to the event table.
/// </summary>
public class EventService(
    IEventEntityManager eventEntityManager,
    IEventRepository eventRepository
    ) : CouscousService, IEventService
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
