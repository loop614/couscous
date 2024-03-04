using CouscousApi.Core;
using Microsoft.AspNetCore.Mvc;
using CouscousApi.DataImport.Transfer;

namespace CouscousApi.EventModule.Controller;

[Route("events/activity")]
[ApiController]
public class EventController : CoreController
{
    private readonly IEventService _eventService;

    public EventController(IEventService activityService)
    {
        this._eventService = activityService;
    }

    [HttpGet("{activity_id}")]
    public List<EventTransfer> GetEvents(int activity_id)
    {
        Console.WriteLine("Getting events for " + activity_id.ToString());
        return this._eventService.GetEvents(activity_id);
    }
}
