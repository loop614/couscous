using CouscousApi.ActivityModule;
using CouscousApi.DataImport.Transfer;
using Newtonsoft.Json;

namespace CouscousApi.DataImport.Importer;

public class ExampleImporter : IExampleImporter
{
    private readonly IActivityFacade _activityFacade;

    public ExampleImporter(IActivityFacade activityFacade)
    {
        _activityFacade = activityFacade;
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

        _activityFacade.SaveActivity(garminActivityMetric);
    }
}
