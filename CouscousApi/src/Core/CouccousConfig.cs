using CouscousApi.ActivityModule;
using CouscousApi.Core.Domain;

namespace CouscousApi.Core;

public static class CouscousConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        DataImportConfig.AddBuilderServices(builder);
        ActivityConfig.AddBuilderServices(builder);

        builder.Services.AddHostedService<CouscousStartupService>();
    }
}
