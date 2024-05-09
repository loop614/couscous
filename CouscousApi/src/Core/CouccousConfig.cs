using CouscousApi.ActivityModule;
using CouscousApi.Core.Persistence;
using CouscousApi.EventElasticModule;
using CouscousApi.EventModule;

namespace CouscousApi.Core;

public static class CouscousConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        AddCoreBuilderServices(builder);
        DataImportConfig.AddBuilderServices(builder);
        ActivityConfig.AddBuilderServices(builder);
        EventElasticConfig.AddBuilderServices(builder);
        EventConfig.AddBuilderServices(builder);
    }

    private static void AddCoreBuilderServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<CouscousElasticClient>();
    }
}
