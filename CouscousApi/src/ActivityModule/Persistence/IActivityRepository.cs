using CouscousApi.ActivityModule.Model;

namespace CouscousApi.ActivityModule.Persistence;

public interface IActivityRepository
{
    public int CountActivities();

    public ActivityTransfer? GetActivity(int idActivity);
}
