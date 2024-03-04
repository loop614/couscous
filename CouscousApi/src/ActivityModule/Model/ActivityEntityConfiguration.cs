using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CouscousApi.ActivityModule.Model;

public class ActivityEntityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder
            .Property(b => b.ActivityType)
            .IsRequired();

        builder
            .Property(b => b.ExternalActivityId)
            .IsRequired();

        builder
            .Property(e => e.ActivityType)
            .HasConversion(
                v => v.ToString(),
                v => (ActivityTypeEnum)Enum.Parse(typeof(ActivityTypeEnum), v));

        builder
            .HasMany(e => e.Metrics);

        builder
            .HasMany(e => e.GeoPoints);

        builder
            .HasMany(e => e.Events);
    }
}
