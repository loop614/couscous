using CouscousApi.Core.Persistence;
using Microsoft.EntityFrameworkCore;

public static class DataExtensions
{
    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CouscousContext>();
        db.Database.Migrate();

        return app;
    }
}
