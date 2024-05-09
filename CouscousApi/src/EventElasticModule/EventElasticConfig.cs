using CouscousApi.EventElasticModule.Persistence;

namespace CouscousApi.EventElasticModule;

public static class EventElasticConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IEventElasticDocumentManager, EventElasticDocumentManager>();
        builder.Services.AddTransient<IEventElasticRepository, EventElasticRepository>();
        builder.Services.AddTransient<IEventElasticService, EventElasticService>();
    }
}
