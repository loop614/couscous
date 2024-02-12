using CouscousApi.ActivityModule.Model;
using CouscousApi.Core.Transfer;
using CouscousApi.GeoPointModule.Model;
using CouscousApi.MetricModule.Model;
using Microsoft.EntityFrameworkCore;

namespace CouscousApi.Core.Persistence;

public class CouscousContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }

    public DbSet<Geopoint> GeoPoints { get; set; }

    public DbSet<Metric> Metrics { get; set; }

    public string DbPath { get; }

    public CouscousContext(IConfiguration config)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var settingsSql = config.GetSection("Sql").Get<CouscousSqlSettings>();
        this.DbPath = settingsSql?.ConnectionString ?? string.Empty;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(this.DbPath);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ActivityEntityConfiguration().Configure(modelBuilder.Entity<Activity>());
    }
}
