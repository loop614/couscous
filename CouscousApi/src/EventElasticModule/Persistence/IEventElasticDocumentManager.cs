using CouscousApi.ActivityModule.Model;
using CouscousApi.DataImport.Transfer;

namespace CouscousApi.EventElasticModule.Persistence;

public interface IEventElasticDocumentManager
{
    void SaveEvents(Activity activity, GarminActivityMetric garminActivityMetrics);
}
