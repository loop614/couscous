using CouscousApi.ActivityModule.Persistence;

namespace CouscousApi.ActivityModule;

public static class ActivityConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IActivityEntityManager, ActivityEntityManager>();
        builder.Services.AddTransient<IActivityRepository, ActivityRepository>();
        builder.Services.AddTransient<IActivityService, ActivityService>();
    }
}
