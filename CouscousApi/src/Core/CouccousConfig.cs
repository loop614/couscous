using CouscousApi.ActivityModule;
using CouscousApi.EventModule;

namespace CouscousApi.Core;

public static class CouscousConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        DataImportConfig.AddBuilderServices(builder);
        ActivityConfig.AddBuilderServices(builder);
        EventConfig.AddBuilderServices(builder);
    }
}
