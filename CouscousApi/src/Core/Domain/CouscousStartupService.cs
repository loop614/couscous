using CouscousApi.DataImport;

namespace CouscousApi.Core.Domain;

public class CouscousStartupService : IHostedService {
    private readonly IServiceScopeFactory scopeFactory;

    public CouscousStartupService(IServiceScopeFactory scopeFactory)
    {
        this.scopeFactory = scopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = this.scopeFactory.CreateScope())
        {
            var dataImportService = scope.ServiceProvider.GetRequiredService<IDataImportService>();
            dataImportService.ImportExample();
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
