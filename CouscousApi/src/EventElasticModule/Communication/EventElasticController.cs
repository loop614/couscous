using Microsoft.AspNetCore.Mvc;
using CouscousApi.DataImport.Transfer;
using CouscousApi.EventElasticModule;

namespace CouscousApi.EventModule.Controller;

[Route("events/elastic/activity")]
[ApiController]
public class EventElasticController(IEventElasticService eventElasticService)
{
    [HttpGet("{activity_id}")]
    public List<EventTransfer> GetEvents(int activity_id)
    {
        Console.WriteLine("Getting events from elastic for activity " + activity_id.ToString());
        return eventElasticService.GetEvents(activity_id);
    }
}
