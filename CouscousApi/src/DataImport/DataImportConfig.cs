using CouscousApi.DataImport;
using CouscousApi.DataImport.Importer;

namespace CouscousApi.ActivityModule;

public static class DataImportConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IExampleImporter, ExampleImporter>();
        builder.Services.AddTransient<IDataImportService, DataImportService>();
    }
}
