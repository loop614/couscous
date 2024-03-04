namespace CouscousApi.DataImport;

public class DataImportService(IExampleImporter exampleImpoter) : IDataImportService
{
    public void ImportExample()
    {
        exampleImpoter.ImportExample();
    }
}
