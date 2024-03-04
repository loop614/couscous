using CouscousApi.EventModule.Persistence;

namespace CouscousApi.EventModule;

public static class EventConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IEventEntityManager, EventEntityManager>();
        builder.Services.AddTransient<IEventRepository, EventRepository>();
        builder.Services.AddTransient<IEventService, EventService>();
    }
}
