using MongoDB.Driver;
using SearchEngine.API.Core.Entity;

namespace SearchEngine.API.Infrastructure.Client
{
    public interface IClient
    {
        IMongoDatabase Database { get; }
        IMongoCollection<Document> DocumentsCollection { get; }
        IMongoCollection<Term> TermsCollection { get; }
    }
}
