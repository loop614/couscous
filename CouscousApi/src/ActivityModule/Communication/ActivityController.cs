using CouscousApi.ActivityModule.Transfer;
using Microsoft.AspNetCore.Mvc;

namespace CouscousApi.ActivityModule.Controller;

[Route("activity/")]
[ApiController]
public class ActivityController(IActivityService activityService)
{
    [HttpGet("{activity_id}")]
    public ActivityTransfer? GetActivity(int activity_id)
    {
        Console.WriteLine("Getting activity " + activity_id.ToString());
        return activityService.GetActivity(activity_id);
    }
}
