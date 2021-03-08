using SearchEngine.API.Core.DomainServices;
using SearchEngine.API.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.API.Core.ApplicationServices.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Document> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Document>> GetDocumentsFromDocTable()
        {
            var documents = await _repository.GetDocumentsFromDocTable();
            return documents;
        }
    }
}
