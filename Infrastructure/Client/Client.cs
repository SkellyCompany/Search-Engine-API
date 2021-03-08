using MongoDB.Driver;
using SearchEngine.API.Core.DomainServices;
using SearchEngine.API.Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.API.Infrastructure.Client.Database;

namespace SearchEngine.API.Infrastructure.Client
{
    public class Client : IClient
    {
        private readonly IDatabaseSettings _dbSettings;
        private readonly IDatabaseMetadata _dbMetadata;
        public IMongoDatabase Database { get; }
        public IMongoCollection<Document> DocumentsCollection
        { 
            get
            {
                return Database.GetCollection<Document>(_dbMetadata.DocumentsCollectionName);
            }
        }
        public IMongoCollection<Term> TermsCollection 
        { 
            get
            {
                return Database.GetCollection<Term>(_dbMetadata.TermsCollectionName);
            }
        }

        public Client(IDatabaseSettings dbSettings, IDatabaseMetadata dbMetadata)
        {
            _dbSettings = dbSettings;
            _dbMetadata = dbMetadata;
            var client = new MongoClient(_dbSettings.ConnectionString);
            Database = client.GetDatabase(_dbSettings.DatabaseName);
        }
    }
}
