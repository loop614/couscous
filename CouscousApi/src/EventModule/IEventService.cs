using CouscousApi.ActivityModule.Model;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule.Model;

namespace CouscousApi.EventModule;

/// <summary>
/// Entrypoint for Event Module, which has access to the event table.
/// </summary>
public interface IEventService
{
    public int CountEvents();

    public List<EventTransfer> GetEvents(int idActivity);

    public List<Event> SaveEvents(Activity activity, GarminActivityMetric garminActivityMetrics);
}
