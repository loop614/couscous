namespace CouscousApi.ActivityModule;

public static class ActivityConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IActivityService, ActivityService>();
    }
}
