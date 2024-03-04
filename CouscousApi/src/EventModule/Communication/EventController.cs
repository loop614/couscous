using CouscousApi.Core;
using Microsoft.AspNetCore.Mvc;
using CouscousApi.DataImport.Transfer;

namespace CouscousApi.EventModule.Controller;

[Route("events/activity")]
[ApiController]
public class EventController(IEventService eventService) : CoreController
{
    [HttpGet("{activity_id}")]
    public List<EventTransfer> GetEvents(int activity_id)
    {
        Console.WriteLine("Getting events for " + activity_id.ToString());
        return eventService.GetEvents(activity_id);
    }
}
