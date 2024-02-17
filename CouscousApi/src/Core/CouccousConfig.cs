using CouscousApi.ActivityModule;

namespace CouscousApi.Core;

public static class CouscousConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        ActivityConfig.AddBuilderServices(builder);
        DataImportConfig.AddBuilderServices(builder);
    }
}
