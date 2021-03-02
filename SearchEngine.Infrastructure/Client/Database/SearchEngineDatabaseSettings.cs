namespace SearchEngine.Infrastructure.Client.Database
{
    public class SearchEngineDatabaseSettings : ISearchEngineDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string DocumentsCollectionName { get; set; }
        public string TermsCollectionName { get; set; }
    }

    
}
