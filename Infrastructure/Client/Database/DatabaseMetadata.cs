namespace SearchEngine.API.Infrastructure.Client.Database
{
    public class DatabaseMetadata : IDatabaseMetadata
    {
        public string DocumentsCollectionName { get; set; }
        public string TermsCollectionName { get; set; }
    }
}