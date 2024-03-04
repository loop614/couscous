using CouscousApi.ActivityModule.Transfer;
using CouscousApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace CouscousApi.ActivityModule.Controller;

[Route("activity/")]
[ApiController]
public class ActivityController : CoreController
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        this._activityService = activityService;
    }

    [HttpGet("{activity_id}")]
    public ActivityTransfer? GetActivity(int activity_id)
    {
        Console.WriteLine("Getting activity " + activity_id.ToString());
        return this._activityService.GetActivity(activity_id);
    }
}
