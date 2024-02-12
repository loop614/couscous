using CouscousApi.ActivityModule;
using CouscousApi.DataImport.Importer;

namespace CouscousApi.DataImport;

public class DataImportFactory
{
    public IExampleImporter CreateImporter()
    {
        return new ExampleImporter(CreateActivityFacade());
    }

    private IActivityFacade CreateActivityFacade()
    {
        return new ActivityFacade();
    }
}
