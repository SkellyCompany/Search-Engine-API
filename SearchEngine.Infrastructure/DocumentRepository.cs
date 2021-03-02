using MongoDB.Driver;
using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchEngine.Infrastructure.Client;
using SearchEngine.Infrastructure.Client.Database;

namespace SearchEngine.Infrastructure
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IClient _client;

        public DocumentRepository(IClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Document>> GetDocumentsFromDocTable() {
            return await _client
                .DocumentsCollection
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<Document> GetById(string id) {
            return await _client
                .DocumentsCollection
                .Find(doc => doc.Id == id)
                .FirstAsync();
        } 
    }
}
