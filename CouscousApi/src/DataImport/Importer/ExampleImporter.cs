using CouscousApi.ActivityModule;
using CouscousApi.ActivityModule.Model;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventModule;
using Newtonsoft.Json;

namespace CouscousApi.DataImport.Importer;

public class ExampleImporter : IExampleImporter
{
    private readonly IActivityService _activityService;

    private readonly IEventService _eventService;

    public ExampleImporter(
        IActivityService activityService,
        IEventService eventService
    ) {
        _activityService = activityService;
        _eventService = eventService;
    }

    public void ImportExample()
    {
        GarminActivityMetric? garminActivityMetric = JsonConvert.DeserializeObject<GarminActivityMetric>(
            File.ReadAllText(@"./src/DataImport/Example/gamin_activity_metrics.json")
        );

        if (garminActivityMetric is null) {
            Console.WriteLine("Could not load file");
            return;
        }

        if (_activityService.CountActivities() == 0) {
            Activity activity = _activityService.SaveActivity(garminActivityMetric);
            _eventService.SaveEvents(activity, garminActivityMetric);
        }
    }
}
