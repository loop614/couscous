using CouscousApi.Core;
using CouscousApi.DataImport.Transfer;
using Microsoft.AspNetCore.Mvc;

namespace CouscousApi.ActivityModule.Controller;

[Route("activity/")]
[ApiController]
public class ActivityController : CoreController
{
    private readonly ActivityFacade activityFacade;

    public ActivityController()
    {
        this.activityFacade = new ActivityFacade();
    }

    [HttpGet("{activity_id}")]
    public GarminActivityMetric GetActivity(int activity_id)
    {
        return this.activityFacade.GetActivity(activity_id);
    }
}
