using SearchEngine.Core.DomainServices;
using SearchEngine.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.Core.AppServices.Implementation
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepo _repo;

        public DocumentService(IDocumentRepo repo)
        {
            _repo = repo;
        }

        public async Task<Document> GetById(string id)
        {
            return await _repo.GetById(id);
        }

        public async Task<IEnumerable<Document>> GetDocumentsFromDocTable()
        {
            var documents = await _repo.GetDocumentsFromDocTable();
            return documents;
        }
    }
}
