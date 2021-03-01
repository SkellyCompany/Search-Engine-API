using MongoDB.Driver;
using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngine.Infrastructure
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly IClient _client;
        public DocumentRepo(IClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Document>> GetDocumentsFromDocTable() => await _client.GetDocuments().Find(_ => true).ToListAsync();

        public async Task<Document> GetById(string id) => await _client.GetDocuments().Find(doc => doc.Id == id).FirstAsync();
    }
}
