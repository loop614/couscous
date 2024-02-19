using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;
using Microsoft.AspNetCore.Mvc;

namespace CouscousApi.ActivityModule.Controller;

[Route("activity/")]
[ApiController]
public class ActivityController : CoreController
{
    private readonly ActivityService activityService;

    public ActivityController(ActivityService activityService)
    {
        this.activityService = activityService;
    }

    [HttpGet("{activity_id}")]
    public GarminActivityMetric GetActivity(int activity_id)
    {
        return this.activityService.GetActivity(activity_id);
    }
}
