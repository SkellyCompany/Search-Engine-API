using MongoDB.Driver;
using SearchEngine.Core.Entity;

namespace SearchEngine.Infrastructure.Client
{
    public interface IClient
    {
        IMongoDatabase Database { get; }
        IMongoCollection<Document> DocumentsCollection { get; }
        IMongoCollection<Term> TermsCollection { get; }
    }
}
