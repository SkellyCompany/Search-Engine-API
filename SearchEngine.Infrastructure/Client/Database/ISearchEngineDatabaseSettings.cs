namespace SearchEngine.Infrastructure.Client.Database
{
    public interface ISearchEngineDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string DocumentsCollectionName { get; set; }
        string TermsCollectionName { get; set; }
    }
}