using MongoDB.Driver;
using SearchEngine.Core.Entity;

namespace SearchEngine.Core.DomainServices
{
    public interface IClient
    {
        IMongoCollection<Document> GetDocuments();
        IMongoCollection<Term> GetTerms();
    }
}
