using MongoDB.Driver;
using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.Infrastructure
{
    public class Client : IClient
    {
        private readonly IMongoCollection<Document> _documents;
        private readonly IMongoCollection<Term> _terms;

        public Client(ISearchEngineDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _documents = database.GetCollection<Document>(settings.DocumentsCollectionName);
            _terms = database.GetCollection<Term>(settings.TermsCollectionName);
        }

        public IMongoCollection<Document> GetDocuments()
        {
            return _documents;
        }

        public IMongoCollection<Term> GetTerms()
        {
            return _terms;
        }
    }
}
