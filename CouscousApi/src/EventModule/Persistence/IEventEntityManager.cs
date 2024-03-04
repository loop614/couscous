using CouscousApi.ActivityModule.Model;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule.Model;

namespace CouscousApi.EventModule.Persistence;

public interface IEventEntityManager
{
    public List<Event> SaveEvents(Activity activity, GarminActivityMetric garminActivityMetrics);
}
