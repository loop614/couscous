using CouscousApi.ActivityModule;
using CouscousApi.Core.Persistence;
using CouscousApi.DataImport.Transfer;
using Newtonsoft.Json;

namespace CouscousApi.DataImport.Importer;

public class ExampleImporter(IActivityService activityService) : IExampleImporter
{
    public void ImportExample()
    {
        GarminActivityMetric? garminActivityMetric = JsonConvert.DeserializeObject<GarminActivityMetric>(
            File.ReadAllText(@"./src/DataImport/Example/gamin_activity_metrics.json")
        );

        if (garminActivityMetric is null) {
            Console.WriteLine("Could not load file");
            return;
        }

        if (activityService.CountActivities() > 0) {
            Console.WriteLine("Activities already there");
            return;
        }

        activityService.SaveActivity(garminActivityMetric);
    }
}
