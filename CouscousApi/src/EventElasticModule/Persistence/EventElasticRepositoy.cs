using CouscousApi.Core.Persistence;
using CouscousApi.EventElasticModule.Model;

namespace CouscousApi.EventElasticModule.Persistence;

public class EventElasticRepository(CouscousElasticClient couscousElasticClient) : IEventElasticRepository
{
    public async Task<List<EventElastic>> GetEvents(int activityId)
    {
        var response = await couscousElasticClient.client!.SearchAsync<EventElastic>(s => s
            .Index("couscous_events")
            .From(0)
            .Size(2000)
            .Query(q => q
                .Term(t => t.ActivityId, activityId)
            )
        );

        return response.Documents.ToList();
    }
}
