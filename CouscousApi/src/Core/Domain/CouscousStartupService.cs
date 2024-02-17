using CouscousApi.DataImport;

namespace CouscousApi.Core.Domain;

public class CouscousStartupService : IHostedService {
    private IDataImportService _dataimportService;
    public CouscousStartupService(IDataImportService dataimportService)
    {
        this._dataimportService = dataimportService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        this._dataimportService.ImportExample();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
