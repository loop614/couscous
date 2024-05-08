using CouscousApi.ActivityModule;
using CouscousApi.Core.Model;
using CouscousApi.EventModule;
using Elastic.Clients.Elasticsearch;

namespace CouscousApi.Core;

public static class CouscousConfig
{
    public static void AddBuilderServices(WebApplicationBuilder builder)
    {
        DataImportConfig.AddBuilderServices(builder);
        ActivityConfig.AddBuilderServices(builder);
        EventConfig.AddBuilderServices(builder);
    }

    public static async Task<int> InitElasticSearchAsync(ElasticSearchSettings settings)
    {
        var essettings = new ElasticsearchClientSettings(new Uri(settings.ConnectionUri));
        var client = new ElasticsearchClient(essettings);
        var response = await client.Indices.CreateAsync("couscous_events");

        return response.IsSuccess() ? 0 : 1;
    }
}
