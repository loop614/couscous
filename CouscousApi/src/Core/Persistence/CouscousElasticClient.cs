using CouscousApi.Core.Model;
using Elastic.Clients.Elasticsearch;

namespace CouscousApi.Core.Persistence;

public class CouscousElasticClient
{
    public ElasticsearchClient? client;

    public CouscousElasticClient(IConfiguration config)
    {
        var essettingsjson = config.GetSection("Elastic").Get<ElasticSearchSettings>();
        if (essettingsjson is null)
        {
            Console.WriteLine("Could not find elasticsearch settings");
            return;
        }
        var essettings = new ElasticsearchClientSettings(new Uri(essettingsjson.ConnectionUri));
        client = new ElasticsearchClient(essettings);
    }

    public async Task<int> InitElasticSearchAsync(string indexName)
    {
        var response = await client!.Indices.CreateAsync(indexName);

        return response.IsSuccess() ? 0 : 1;
    }
}
