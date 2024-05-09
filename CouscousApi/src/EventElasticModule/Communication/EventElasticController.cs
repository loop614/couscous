using Microsoft.AspNetCore.Mvc;
using CouscousApi.EventElasticModule;
using CouscousApi.EventElasticModule.Model;

namespace CouscousApi.EventModule.Controller;

[Route("events/elastic/activity")]
[ApiController]
public class EventElasticController(IEventElasticService eventElasticService)
{
    [HttpGet("{activity_id}")]
    public async Task<List<EventElastic>> GetEvents(int activity_id)
    {
        Console.WriteLine("Getting events from elastic for activity " + activity_id.ToString());
        return await eventElasticService.GetEvents(activity_id);
    }
}
