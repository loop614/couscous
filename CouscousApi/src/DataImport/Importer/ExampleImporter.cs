using CouscousApi.ActivityModule;
using CouscousApi.DataImport.Transfer;
using Newtonsoft.Json;

namespace CouscousApi.DataImport.Importer;

public class ExampleImporter : IExampleImporter
{
    private readonly IActivityService _activityService;

    public ExampleImporter(IActivityService activityService)
    {
        _activityService = activityService;
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

        _activityService.SaveActivity(garminActivityMetric);
    }
}
