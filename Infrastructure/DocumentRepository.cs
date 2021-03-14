using MongoDB.Driver;
using SearchEngine.API.Core.DomainServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.API.Infrastructure.Client;
using SearchEngine.API.Core.Domain.Entity;

namespace SearchEngine.API.Infrastructure
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IClient _client;

        public DocumentRepository(IClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Document>> GetDocumentsFromDocTable()
        {
            return await _client
                .DocumentsCollection
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<Document> GetById(string id)
        {
            return await _client
                .DocumentsCollection
                .Find(doc => doc.Id == id)
                .FirstAsync();
        }
    }
}
