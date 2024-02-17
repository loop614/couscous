namespace CouscousApi.DataImport;

public class DataImportService : IDataImportService
{
    IExampleImporter _exampleImpoter;

    public DataImportService(IExampleImporter exampleImpoter)
    {
        this._exampleImpoter = exampleImpoter;
    }

    public void ImportExample()
    {
        this._exampleImpoter.ImportExample();
    }
}
