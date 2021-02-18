namespace SearchEngine.Core.Entity
{
    public class SearchEngineDatabaseSettings : ISearchEngineDatabaseSettings
    {
        public string DocumentsCollectionName { get; set; }
        public string TermsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ISearchEngineDatabaseSettings
    {
        string DocumentsCollectionName { get; set; }
        string TermsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
