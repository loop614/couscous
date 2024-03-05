using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Transfer;
using CouscousApi.EventModule.Model;
using Microsoft.EntityFrameworkCore;

namespace CouscousApi.Core.Persistence;

public class CouscousContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }

    public DbSet<Event> Events { get; set; }

    public string DbPath { get; set; }

    public CouscousContext(IConfiguration config)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var settingsSql = config.GetSection("Sql").Get<CouscousSqlSettings>();
        DbPath = settingsSql?.ConnectionString ?? string.Empty;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(DbPath);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ActivityEntityConfiguration().Configure(modelBuilder.Entity<Activity>());
        new EventEntityConfiguration().Configure(modelBuilder.Entity<Event>());
    }
}
