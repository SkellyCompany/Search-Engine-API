namespace SearchEngine.Infrastructure.Client.Database
{
    public interface IDatabaseMetadata
    {
        string DocumentsCollectionName { get; set; }
        string TermsCollectionName { get; set; }
    }
}