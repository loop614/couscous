using CouscousApi.ActivityModule.Model;
using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule.Model;
using CouscousApi.EventModule.Persistence;

namespace CouscousApi.EventModule;

/// <summary>
/// Entrypoint for Event Module, which has access to the event table.
/// </summary>
public class EventService : CouscousService, IEventService
{
    private readonly IEventEntityManager _eventEntityManager;

    private readonly IEventRepository _eventRepository;

    public EventService(
        IEventEntityManager eventEntityMangager,
        IEventRepository eventRepository
    ) {
        this._eventEntityManager = eventEntityMangager;
        this._eventRepository = eventRepository;
    }

    public int CountEvents()
    {
        return this._eventRepository.CountEvents();
    }

    public List<EventTransfer> GetEvents(int idEvent)
    {
        return this._eventRepository.GetEvents(idEvent);
    }

    public List<Event> SaveEvents(Activity activity, GarminActivityMetric garminEventMetrics)
    {
        return this._eventEntityManager.SaveEvents(activity, garminEventMetrics);
    }
}
